using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Verifying
{
    public class Verify
    {
        [JsonProperty("signature")]
        public SignatureData SignatureData { get; set; }

        [JsonProperty("signParams")]
        public SignatureParameters SignatureParameters { get; set; }

        [JsonProperty("signer")]
        public SignerParameters SignerParameters { get;set; }

        [JsonProperty("options")]
        public SignatureOptions Options { get; set; }
    }
}
