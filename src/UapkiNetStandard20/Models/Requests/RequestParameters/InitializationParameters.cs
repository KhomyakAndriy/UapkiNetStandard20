using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class InitializationParameters
    {
        [JsonProperty("cmProviders")]
        public CmProviders CmProviders { get; set; }

        [JsonProperty("certCache")]
        public CertificateCache CertificateCache { get; set; }

        [JsonProperty("crlCache")]
        public CrlCache CrlCache { get; set; }

        [JsonProperty("tsp")]
        public TspAddress TspAddress { get; set; }

        [JsonProperty("offline")]
        public bool Offline { get; set; }
    }

    internal class CmProviders
    {
        [JsonProperty("dir")]
        public string Directory { get; set; }

        [JsonProperty("allowedProviders")]
        public IEnumerable<AllowedProvider> AllowedProviders { get; set; }


    }

    internal class AllowedProvider
    {
        [JsonProperty("lib")]
        public string Library { get; set; }
    }

    internal class CertificateCache
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("trustedCerts")]
        public IEnumerable<string> TrustedCertificates { get; set; }
    }

    internal class CrlCache
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }

    internal class TspAddress
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
