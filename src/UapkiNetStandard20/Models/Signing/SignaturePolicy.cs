using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Signing
{
    public class SignaturePolicy
    {
        [JsonProperty("sigPolicyId")]
        public string PolicyId { get; set; }

        public static SignaturePolicy Default => new SignaturePolicy
        {
            PolicyId = "1.2.804.2.1.1.1.2.1"
        };
    }
}
