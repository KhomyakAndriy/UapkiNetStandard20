using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class AddCrlParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }
    }
}
