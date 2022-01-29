using Newtonsoft.Json;
using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Models.Signing
{
    public class SignParameters
    {
        [JsonProperty("signatureFormat")]
        public SignatureFormat Format { get; set; }

        [JsonProperty("signAlgo")]
        public string Algorithm { get; set; }

        [JsonProperty("digestAlgo")]
        public string Digest { get; set; }

        [JsonProperty("detachedData")]
        public bool IsDataDetached { get; set; }

        [JsonProperty("includeCert")]
        public bool NeedIncludeCertificate { get; set; }

        [JsonProperty("includeTime")]
        public bool NeedIncludeHostTimestamp { get; set; }

        [JsonProperty("includeContentTS")]
        public bool NeedIncludeContentTimestamp { get; set; }

        //TODO: Uncomment after implementation in library
        //[JsonProperty("certs")]
        //public string[] Certificates { get; set; }

        public SignParameters()
        {
            Algorithm = null;
            Digest = null;
            IsDataDetached = true;
            NeedIncludeCertificate = false;
            NeedIncludeHostTimestamp = false;
            NeedIncludeContentTimestamp = false;
        }
    }
}
