﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UapkiNetStandard20.Common;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;
using UapkiNetStandard20.Models;
using UapkiNetStandard20.Models.Requests;
using UapkiNetStandard20.Models.Requests.RequestParameters;
using UapkiNetStandard20.Models.Signing;
using UapkiNetStandard20.Models.Verifying;
using Empty = System.Object;

namespace UapkiNetStandard20
{
    public class UapkiNet: IDisposable
    {
        private const int IndexNotFound = -1;

        private IntPtr _libraryHandle = IntPtr.Zero;
        private Delegates _delegates = null;
        private VersionInformation _versionInformation;
        private List<Provider> _providers;
        private readonly string _libraryAbsolutePath;

        public UapkiNet(string libraryAbsolutePath)
        {
            if (!UnmanagedLibrary.CheckIsAbsolutePath(libraryAbsolutePath))
            {
                throw new ArgumentException("Path must be absolute", nameof(libraryAbsolutePath));
            }

            _libraryHandle = UnmanagedLibrary.Load(libraryAbsolutePath);
            _delegates = new Delegates(_libraryHandle);
            _versionInformation = Process<VersionInformation>(new VersionRequest());
            _libraryAbsolutePath = libraryAbsolutePath;
        }

        public VersionInformation Version()
        {
            return _versionInformation;
        }

        public InitializationInformation Init(string certCachePath, string crlCachePath, string defaultTspUrl, List<byte[]> trustedCerts, bool offline = false)
        {
            List<string> tCerts = null;

            if (trustedCerts != null)
            {
                tCerts = new List<string>();
                foreach (var trustedCert in trustedCerts)
                {
                    tCerts.Add(Convert.ToBase64String(trustedCert));
                }
            }

            var intitRequest = new InitializationRequest
            {
                Parameters = new InitializationParameters
                {
                    CmProviders = new CmProviders($"{Path.GetDirectoryName(_libraryAbsolutePath)}\\"),
                    CertificateCache = new CertificateCache
                    {
                        Path = certCachePath,
                        TrustedCertificates = tCerts
                    },
                    CrlCache = new CrlCache
                    {
                        Path = crlCachePath
                    },
                    TspAddress = new TspAddress
                    {
                        Url = defaultTspUrl
                    },
                    Offline = offline
                }
            };

            var result = Process<InitializationInformation>(intitRequest);
            _providers = GetProviders();
            return result;
        }

        public void DeInit()
        {
            Process<Empty>(new DeInitRequest());
        }

        public List<Provider> GetProvidersFullInfo()
        {
            var providers = GetProviders();

            if (providers != null && providers.Count > 0)
            {
                foreach (var provider in providers)
                {
                    provider.Storages = GetProviderStorages(provider);
                    provider.Storages?.ForEach(f => f.StorageInfo = GetStorageInfo(f));
                }
            }

            return providers;
        }

        public List<Provider> GetProviders()
        {
            return _providers ?? Process<ProvidersList>(new ProvidersRequest())?.Providers; 
        }

        public List<Storage> GetProviderStorages(Provider provider)
        {
            try
            {
                var storages = Process<StoragesList>(new StoragesRequest(provider.Id))?.Storages;
                storages?.ForEach(storage => storage.ProviderId = provider.Id);
                return storages;
            }
            catch (UapkiException e)
            {
                if (e.ErrorCode == 1030)
                    return null;

                throw;
            }
        }

        public StorageInfo GetStorageInfo(Storage storage)
        {
            try
            {
                return Process<StorageInfo>(new StorageInfoRequest(storage.ProviderId, storage.Id));
            }
            catch (UapkiException e)
            {
                if (e.ErrorCode == 1030)
                    return null;

                throw;
            }
        }

        public Storage OpenStorage(IStorageOpenParameters openParameters)
        {
            if (openParameters == null)
                throw new ArgumentNullException(nameof(openParameters), "Provide Storage open parameters");

            //TODO: Implement storageOpenParameters for different storage types


            var storage = Process<Storage>(new OpenStorageRequest(openParameters));
            if (storage == null)
                throw new Exception("Open storage unknown error");

            storage.Id = openParameters.Storage;
            storage.ProviderId = openParameters.Provider;
            storage.StorageOpenParameters = openParameters;
            storage.StorageInfo = GetStorageInfo(storage);
            storage.Keys = GetOpenedStorageKeys();

            return storage;
        }

        public void CloseStorage()
        {
            Process<Empty>(new CloseStorageRequest());
        }

        public List<KeyInfo> GetOpenedStorageKeys()
        {
            return Process<KeysList>(new KeysRequest())?.Keys;
        }

        public void SelectKey(Storage storage, string keyId)
        {
            var keyIndex = storage.Keys.FindIndex(key => key.Id.Equals(keyId));
            if (keyIndex == IndexNotFound)
                throw new ArgumentException($"Storage has no key with Id \"{keyId}\"", nameof(keyId));
            SelectKey(storage, keyIndex);
        }

        public void SelectKey(Storage storage, int keyIndex)
        {
            var key = storage.Keys[keyIndex];
            var additionalInfo = Process<SelectedKeyInfo>(new SelectKeyRequest(key.Id));

            key.SigningAlgorithms = additionalInfo.SigningAlgorithms;
            key.CertificateId = additionalInfo.CertificateId;
            key.Certificate = Convert.FromBase64String(additionalInfo.CertificateBase64);
            key.IsSelected = true;
        }

        public string CreateKey(Storage storage, int? mechanismIndex = null, string parameter = null, string label = null)
        {
            var id = Process<string>(new CreateKeyRequest(new CreateKeyParameters()
            {
                Mechanism = mechanismIndex == null ? null : storage.Mechanisms[mechanismIndex.Value].Id,
                Parameter = parameter,
                Label = label
            }));
            storage.Keys = GetOpenedStorageKeys();
            return id;
        }

        public void DeleteKey(Storage storage, int keyIndex) 
        {
            var key = storage.Keys[keyIndex];
            Process<Empty>(new DeleteKeyRequest(key.Id));
            storage.Keys = GetOpenedStorageKeys();
        }

        public byte[] GenerateCertificateSigningRequest(Storage storage, string signAlgorithm = null)
        {
            if (string.IsNullOrWhiteSpace(signAlgorithm))
                return GenerateCertificateSigningRequest(storage, (int?)null);
            
            var signAlgorithmIndex = storage.Keys.First(f => f.IsSelected).SigningAlgorithms.FindIndex(alg => alg.Equals(signAlgorithm));
            if (signAlgorithmIndex == IndexNotFound)
                throw new ArgumentException($"Selected key has no sign algorithm \"{signAlgorithm}\"", nameof(signAlgorithm));

            return GenerateCertificateSigningRequest(storage, signAlgorithmIndex);
        }

        public byte[] GenerateCertificateSigningRequest(Storage storage, int? signAlgorithmIndex = null)
        {
            var signAlgorithm = signAlgorithmIndex.HasValue ? 
                storage.Keys.First(f => f.IsSelected).SigningAlgorithms[signAlgorithmIndex.Value] : 
                null;

            var result = Process<Csr>(new GetCsrRequest(signAlgorithm));
            return Convert.FromBase64String(result.BytesBase64);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Process<Empty>(new ChangePasswordRequest(oldPassword, newPassword));
        }

        public object InitKeyUsage(object parameters)
        {
            return Process<object>(new InitKeyUsageRequest(parameters));
        }

        public List<SignatureResult> Sign(Sign sign)
        {
            return Process<SigningResponse>(new SignRequest(sign)).Signatures;
        }

        public IVerificationResult Verify(SignatureFormat format, Verify verify)
        {
            switch (format)
            {
                case SignatureFormat.Cms:
                case SignatureFormat.CadesBes:
                    return Process<CadesOrCmsVerificationResult>(new VerifyRequest(format, verify));
                case SignatureFormat.Raw:
                    return Process<RawVerificationResult>(new VerifyRequest(format, verify));
                default:
                    throw new NotImplementedException($"Verification for format \"{format:G}\" not implemented in this version");
            }
        }

        private unsafe TResponse Process<TResponse>(BaseRequest request)
        {
            byte* resultPtr = (byte*)_delegates.Process(request.ToJson());
            string result = null;
            if (resultPtr != null)
            {
                try
                {
                    int length = 0;
                    for (byte* i = resultPtr; *i != 0; i++, length++) ;
                    result = Encoding.UTF8.GetString(resultPtr, length);
                }
                finally
                {
                    _delegates.JsonFree((IntPtr)resultPtr);
                }
            }
            if (string.IsNullOrWhiteSpace(result))
            {
                return default;
            }

            var resultModel = JsonConvert.DeserializeObject<CommonResponse<TResponse>>(result);

            if (!resultModel.IsSuccess)
            {
                throw new UapkiException(resultModel.ErrorCode, resultModel.Error);
            }

            return resultModel.Result;
        }

        public void Dispose()
        {
            try
            {
                DeInit();
                UnmanagedLibrary.Unload(_libraryHandle);
            }
            finally
            {
                _libraryHandle = IntPtr.Zero;
                _delegates.Clear();
                _delegates = null;
            }
        }
    }
}
