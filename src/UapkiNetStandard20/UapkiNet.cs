using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UapkiNetStandard20.Common;
using UapkiNetStandard20.Models;
using UapkiNetStandard20.Models.Requests;
using UapkiNetStandard20.Models.Requests.RequestParameters;
using Empty = System.Object;

namespace UapkiNetStandard20
{
    public class UapkiNet: IDisposable
    {
        private IntPtr _libraryHandle = IntPtr.Zero;
        private Delegates _delegates = null;
        private VersionInformation _versionInformation;

        public UapkiNet(string libraryAbsolutePath)
        {
            if (!UnmanagedLibrary.CheckIsAbsolutePath(libraryAbsolutePath))
            {
                throw new ArgumentException("Path must be absolute", nameof(libraryAbsolutePath));
            }

            _libraryHandle = UnmanagedLibrary.Load(libraryAbsolutePath);
            _delegates = new Delegates(_libraryHandle);
            _versionInformation = Process<VersionInformation>(new VersionRequest());
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
                    CmProviders = new CmProviders
                    {
                        Directory = "",
                        AllowedProviders = new AllowedProvider[] {
                            new AllowedProvider {
                                Library = "cm-pkcs12"
                            },
                            new AllowedProvider {
                                Library = "cm-diamond"
                            },
                            new AllowedProvider {
                                Library = "cm-almaz1c"
                            },
                            new AllowedProvider {
                                Library = "cm-crystal1"
                            },
                            new AllowedProvider {
                                Library = "cm-stoken"
                            }
                        }
                    },
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

            return Process<InitializationInformation>(intitRequest);
        }

        public void DeInit()
        {
            Process<Empty>(new BaseRequest<Empty>("DEINIT"));
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
                return default(TResponse);
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
