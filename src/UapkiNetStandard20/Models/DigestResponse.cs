using Newtonsoft.Json;

namespace UapkiNetStandard20.Models
{
    internal class DigestResponse
    {
        [JsonProperty("hashAlgo")]
        public string HashAlgorithm { get; set; }

        [JsonProperty("signAlgo")]
        public string SignAlgorithm { get; set; }

        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
