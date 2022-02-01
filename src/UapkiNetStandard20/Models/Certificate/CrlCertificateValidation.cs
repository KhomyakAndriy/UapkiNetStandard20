using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.Certificate
{
    public class CrlCertificateValidation : ICertificateValidation
    {
        [JsonProperty("status")]
        public CertificateStatus Status { get ; set; }

        [JsonProperty("revocationReason")]
        public RevocationReason? RevocationReason { get; set; }

        [JsonProperty("revocationTime")]
        public DateTime? RevocationTime { get; set; }

        [JsonProperty("full")]
        public CrlInformation FullInformation { get; set; }

        [JsonProperty("delta")]
        public CrlInformation DeltaInformation { get; set; }
    }
}
