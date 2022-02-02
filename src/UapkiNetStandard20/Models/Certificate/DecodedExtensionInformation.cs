using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Certificate
{
    public class DecodedExtensionInformation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public Dictionary<string, object> Value { get; set; }
    }
}
