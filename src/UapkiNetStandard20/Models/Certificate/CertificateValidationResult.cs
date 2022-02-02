using Newtonsoft.Json;
using System;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.Certificate
{
    public class CertificateValidationResult
    {
        [JsonProperty("validateByCRL")]
        internal CrlCertificateValidation ValidationCrl { get; set; }

        [JsonProperty("validateByOCSP")]
        internal OcspCertificateValidation ValidationOcsp { get; set; }

        [JsonProperty("validateTime")]
        public DateTime ValidateTime { get; set; }

        [JsonProperty("subjectCertId")]
        public string SubjectCertificateId { get; set; }

        [JsonProperty("validity")]
        public ValidityTimeStamp Validity { get; set; }

        [JsonProperty("expired")]
        public bool IsExpired { get; set; }

        [JsonProperty("selfSigned")]
        public bool IsSelfSigned { get; set; }

        [JsonProperty("trusted")]
        public bool IsTrusted { get; set; }

        [JsonProperty("statusSignature")]
        public VerificationStatus StatusSignature { get; set; }

        [JsonProperty("issuerCertId")]
        public string IssuerCertificateId { get; set; }

        public ICertificateValidation Validation => (ICertificateValidation)ValidationCrl ?? ValidationOcsp;
    }
}
