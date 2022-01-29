using Newtonsoft.Json;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.Verifying
{
    public class RawVerificationResult: IVerificationResult
    {
        [JsonProperty("statusSignature")]
        public VerificationStatus Status { get; set; }
    }
}
