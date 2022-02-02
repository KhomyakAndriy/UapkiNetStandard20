using Newtonsoft.Json;
using System.Collections.Generic;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.Verifying
{
    public class CadesOrCmsVerificationResult: IVerificationResult
    {
        [JsonProperty("content")]
        public VerificationContentInfo Content { get; set; }

        [JsonProperty("certIds")]
        public List<string> CertificateIds { get; set; }

        [JsonProperty("signatureInfos")]
        public List<SignatureInformation> SignatureInformations { get; set; }
    }
}
