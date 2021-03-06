using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CreateKeyParameters
    {
        [JsonProperty("mechanism")]
        public string Mechanism { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
