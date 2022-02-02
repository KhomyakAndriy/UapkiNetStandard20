using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Signing
{
    public class AttributeParameters
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
