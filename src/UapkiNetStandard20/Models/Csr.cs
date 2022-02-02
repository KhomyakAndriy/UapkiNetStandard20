using Newtonsoft.Json;

namespace UapkiNetStandard20.Models
{
    internal class Csr
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
