using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Crl
{
    public class CrlInformation
    {
        [JsonProperty("issuer")]
        public Dictionary<string, string> Issuer { get; set; }

        [JsonProperty("thisUpdate")]
        public DateTime ThisUpdate { get; set; }

        [JsonProperty("nextUpdate")]
        public DateTime NextUpdate { get; set; }

        [JsonProperty("countRevokedCerts")]
        public int RevokedCount { get; set; }

        [JsonProperty("authorityKeyId")]
        public string AuthorityKeyId { get; set; }

        [JsonProperty("crlNumber")]
        public string Number { get; set; }

        [JsonProperty("deltaCrlIndicator")]
        public string DeltaCrlIndicator { get; set; }

        [JsonProperty("revokedCerts")]
        public List<RevokedCertificateInformation> RevokedCertificates { get; set; }
    }
}
