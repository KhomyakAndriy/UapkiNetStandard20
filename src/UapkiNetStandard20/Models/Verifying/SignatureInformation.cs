using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Models.Verifying
{
    public class SignatureInformation
    {
        [JsonProperty("signerCertId")]
        public string CertificateId { get; set; }

        [JsonProperty("status")]
        public FullVerificationStatus Status { get; set; }

        [JsonProperty("statusSignature")]
        public VerificationStatus SignatureStatus { get; set; }

        [JsonProperty("statusMessageDigest")]
        public VerificationStatus DigestStatus { get; set; }

        [JsonProperty("statusEssCert")]
        public CertificateValidationStatus CertificateStatus { get; set; }

        [JsonProperty("signingTime")]
        public DateTime SigningTime { get; set; }

        [JsonProperty("signedAttributes")]
        //TODO: Required UAPKI documentation update
        public List<object> SignedAttributes { get; set; }

        [JsonProperty("unsignedAttributes")]
        //TODO: Required UAPKI documentation update
        public List<object> UnsignedAttributes { get; set; }

        [JsonProperty("contentTS")]
        public List<VerificationTimeStamp> ContentTimestamp { get; set; }

        [JsonProperty("signatureTS")]
        public List<VerificationTimeStamp> SignatureTimeStamp { get; set; }
    }
}
