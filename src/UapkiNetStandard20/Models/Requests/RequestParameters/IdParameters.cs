using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class IdParameters
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
