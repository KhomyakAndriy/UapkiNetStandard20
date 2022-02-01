using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Asn1
{
    public class ItemToEncode
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("integer")]
        public int Integer { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
