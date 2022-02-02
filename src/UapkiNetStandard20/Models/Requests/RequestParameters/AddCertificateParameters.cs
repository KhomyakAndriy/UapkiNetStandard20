using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class AddCertificateParameters
    {
        [JsonProperty("certificates")]
        public IEnumerable<string> CertificatesBase64 { get; set; }

        [JsonProperty("bundle")]
        public string Bundle { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }
    }
}
