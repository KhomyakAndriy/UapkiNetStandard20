using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UapkiNetStandard20.Common;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;
using UapkiNetStandard20.Models;
using UapkiNetStandard20.Models.Asn1;
using UapkiNetStandard20.Models.Certificate;
using UapkiNetStandard20.Models.Crl;
using UapkiNetStandard20.Models.Requests;
using UapkiNetStandard20.Models.Requests.RequestParameters;
using UapkiNetStandard20.Models.Signing;
using UapkiNetStandard20.Models.Verifying;
using UapkiNetStandard20.Utils;
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
        private readonly Logger _logger;

        public delegate void Logger(LogLevel logLevel, string message, Exception exception = null);

        public UapkiNet(string libraryAbsolutePath, Logger logger = null)
        {
            if (!UnmanagedLibrary.CheckIsAbsolutePath(libraryAbsolutePath))
            {
                throw new ArgumentException("Path must be absolute", nameof(libraryAbsolutePath));
            }

            _libraryHandle = UnmanagedLibrary.Load(libraryAbsolutePath);
            _delegates = new Delegates(_libraryHandle);
            _versionInformation = Process<VersionInformation>(new VersionRequest());
            _libraryAbsolutePath = libraryAbsolutePath;
            _logger = logger;
        }

        public VersionInformation Version()
        {
            return _versionInformation;
        }

        public InitializationInformation Init(
            string certCachePath = "certs/", 
            string crlCachePath = "certs/crls/", 
            string defaultTspUrl = "http://acskidd.gov.ua/services/tsp/", 
            List<byte[]> trustedCerts = null, 
            bool offline = false
            )
        {
            if (!Directory.Exists(certCachePath))
                Directory.CreateDirectory(certCachePath);

            if (!Directory.Exists(crlCachePath))
                Directory.CreateDirectory(crlCachePath);

            var intitRequest = new InitializationRequest
            {
                Parameters = new InitializationParameters
                {
                    CmProviders = new CmProviders($"{Path.GetDirectoryName(_libraryAbsolutePath)}\\"),
                    CertificateCache = new CertificateCache
                    {
                        Path = certCachePath,
                        TrustedCertificates = trustedCerts?.Select(s=> Convert.ToBase64String(s))
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
            storage.SetParentLibrary(this);

            return storage;
        }

        #region Only for opened storage

        internal void CloseStorage()
        {
            Process<Empty>(new CloseStorageRequest());
        }

        internal StorageInfo GetStorageInfo(Storage storage)
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

        internal List<KeyInfo> GetOpenedStorageKeys()
        {
            var keys = Process<KeysList>(new KeysRequest())?.Keys;
            if (keys != null)
            {
                foreach (var key in keys)
                {
                    key.SetParentLibrary(this);
                }
            }
            return keys;
        }

        internal void SelectKey(KeyInfo key)
        {
            var additionalInfo = Process<SelectedKeyInfo>(new SelectKeyRequest(key.Id));

            key.SigningAlgorithms = additionalInfo.SigningAlgorithms;
            key.CertificateId = additionalInfo.CertificateId;
            key.Certificate = ConvertExtension.FromBase64OrNull(additionalInfo.CertificateBase64);
            key.IsSelected = true;
        }

        internal string CreateKey(string mechanismId, string parameter = null, string label = null)
        {
            return Process<string>(new CreateKeyRequest(new CreateKeyParameters()
            {
                Mechanism = mechanismId,
                Parameter = parameter,
                Label = label
            }));
        }

        internal void DeleteKey(string keyId) 
        {
            Process<Empty>(new DeleteKeyRequest(keyId));
        }

        internal byte[] GenerateCertificateSigningRequest(string signAlgorithm = null)
        {
            var result = Process<Csr>(new GetCsrRequest(signAlgorithm));
            return Convert.FromBase64String(result.BytesBase64);
        }

        internal void ChangePassword(string oldPassword, string newPassword)
        {
            Process<Empty>(new ChangePasswordRequest(oldPassword, newPassword));
        }

        internal object InitKeyUsage(object parameters)
        {
            return Process<object>(new InitKeyUsageRequest(parameters));
        }

        internal List<SignatureResult> Sign(Sign sign)
        {
            return Process<SigningResponse>(new SignRequest(sign)).Signatures;
        }

        #endregion

        public IVerificationResult Verify(Verify verify, SignatureFormat format = SignatureFormat.Cms)
        {        
            switch (format)
            {
                case SignatureFormat.Cms:
                case SignatureFormat.CadesBes:
                case SignatureFormat.CadesT:
                    return Process<CadesOrCmsVerificationResult>(new VerifyRequest(format, verify));
                case SignatureFormat.Raw:
                    return Process<RawVerificationResult>(new VerifyRequest(format, verify));
                default:
                    throw new NotImplementedException($"Verification for format \"{format:G}\" not implemented in this version");
            }
        }

        public List<CertificateStorageRecord> AddCertificates(byte[][] certificates, bool permanent)
        {
            return Process<AddCertificateResult>(new AddCertificateRequest(certificates, permanent)).Certificates;
        }

        public List<CertificateStorageRecord> AddCertificates(byte[] bundle, bool permanent)
        {
            return Process<AddCertificateResult>(new AddCertificateRequest(bundle, permanent)).Certificates;
        }

        public CertificateV3 GetCertificateInformation(byte[] certificate)
        {
            return Process<CertificateV3>(new CertificateInformationRequest(certificate));
        }

        public CertificateV3 GetCertificateInformation(string certificateId)
        {
            return Process<CertificateV3>(new CertificateInformationRequest(certificateId));
        }

        public byte[] GetCertificateFromCache(string certificateId)
        {
            return Process<Bytes>(new GetCertificateRequest(certificateId)).Data;
        }

        public List<string> GetAllCertificateIdsFromCache()
        {
            return GetCertificateIdsByPage().Ids;
        }

        public CertificateCachePage GetCertificateIdsByPage(int pageNumber = 0, int? pageSize = null)
        {
            return Process<CertificateCachePage>(new ListCertificatesRequest(pageNumber, pageSize));
        }

        public void RemoveCertificateFromCache(string certificateId)
        {
            Process<Empty>(new RemoveCertificateFromCacheRequest(certificateId));
        }

        public CertificateValidationResult VerifyCertificate(byte[] certificate, CertificateValidationType validationType, DateTime? crlValidateTime)
        {
            return Process<CertificateValidationResult>(new VerifyCertificateRequest(certificate, validationType, crlValidateTime));
        }

        public CertificateValidationResult VerifyCertificate(string certificateId, CertificateValidationType validationType, DateTime? crlValidateTime)
        {
            return Process<CertificateValidationResult>(new VerifyCertificateRequest(certificateId, validationType, crlValidateTime));
        }

        public CrlStorageRecord AddCrl(byte[] crlBytes, bool permanent)
        {
            return Process<CrlStorageRecord>(new AddCrlRequest(crlBytes, permanent));
        }

        public CrlInformation GetCrlInformation(byte[] crlBytes)
        {
            return Process<CrlInformation>(new CrlInfoRequest(crlBytes));
        }

        public byte[] Digest(byte[] data, string algorithm = "2.16.840.1.101.3.4.2.1", bool isHashAlgorithm = true) //SHA-256
        {
            return ConvertExtension.FromBase64OrNull(Process<DigestResponse>(new DigestRequest(data, algorithm, isHashAlgorithm)).BytesBase64);
        }

        public byte[] Digest(string filePath, string algorithm = "2.16.840.1.101.3.4.2.1", bool isHashAlgorithm = true) //SHA-256
        {
            return ConvertExtension.FromBase64OrNull(Process<DigestResponse>(new DigestRequest(filePath, algorithm, isHashAlgorithm)).BytesBase64);
        }

        public byte[] Digest(string ptr, int size, string algorithm = "2.16.840.1.101.3.4.2.1", bool isHashAlgorithm = true) //SHA-256
        {
            return ConvertExtension.FromBase64OrNull(Process<DigestResponse>(new DigestRequest(ptr, size, algorithm, isHashAlgorithm)).BytesBase64);
        }

        public List<DecodedItem> Asn1Decode(List<ItemToDecode> itemsToDecode)
        {
            return Process<Asn1DecodedItems>(new Asn1DecodeRequest(itemsToDecode)).Decoded;
        }

        public List<EncodedItem> Asn1Encode(List<ItemToEncode> itemsToEncode)
        {
            return Process<Asn1EncodedItems>(new Asn1EncodeRequest(itemsToEncode)).Encoded;
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

        private unsafe TResponse Process<TResponse>(BaseRequest request)
        {
            var json = request.ToJson();
            _logger?.Invoke(LogLevel.Debug, $"Start sending request:\n{json}");
            byte* resultPtr = (byte*)_delegates.Process(json);
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
                var ex = new UapkiException(resultModel.ErrorCode, resultModel.Error);
                _logger?.Invoke(LogLevel.Error, ex.Message, ex);
                throw ex;
            }

            return resultModel.Result;
        }
    }
}
