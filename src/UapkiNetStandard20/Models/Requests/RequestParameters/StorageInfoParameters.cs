using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class StorageInfoParameters
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("storage")]
        public string Storage { get; set; }
    }
}
