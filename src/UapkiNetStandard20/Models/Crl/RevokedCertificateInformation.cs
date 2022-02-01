using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Models.Crl
{
    public class RevokedCertificateInformation
    {
        [JsonProperty("userCertificate")]
        public string UserCertificate { get; set; }

        [JsonProperty("revocationDate")]
        public DateTime Date { get; set; }

        [JsonProperty("crlReason")]
        public RevocationReason Reason { get; set; }

        [JsonProperty("invalidityDate")]
        public DateTime InvalidityDate { get; set; }
    }
}
