using Newtonsoft.Json;

namespace UapkiNetStandard20.Models
{
    public class InitializationInformation
    {
        [JsonProperty("certCache")]
        public CertificateCacheInformation CertificateCache { get; set; }

        [JsonProperty("crlCache")]
        public ClrCacheInformation ClrCache { get; set; }

        [JsonProperty("countCmProviders")]
        public int CmProvidersCount { get; set; }

        [JsonProperty("offline")]
        public bool Offline { get; set; }

        [JsonProperty("tsp")]
        public TspInformation Tsp { get; set; }
    }

    public class CertificateCacheInformation
    {
        [JsonProperty("countCerts")]
        public int CertificateCount { get; set; }

        [JsonProperty("countTrustedCerts")]
        public int TrustedCertificatesCount { get; set; }
    }

    public class ClrCacheInformation
    {
        [JsonProperty("countCrls")]
        public int Count { get; set; }
    }

    public class TspInformation
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("policyId")]
        public string PolicyId { get; set; }
    }
}
