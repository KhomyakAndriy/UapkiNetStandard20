using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CrlInfoParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
