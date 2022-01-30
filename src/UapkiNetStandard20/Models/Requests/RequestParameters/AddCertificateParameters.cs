using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
