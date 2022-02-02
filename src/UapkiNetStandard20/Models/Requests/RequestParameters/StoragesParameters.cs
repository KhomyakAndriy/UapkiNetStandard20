using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class StoragesParameters
    {

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}
