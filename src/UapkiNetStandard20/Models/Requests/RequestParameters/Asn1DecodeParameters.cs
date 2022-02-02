using Newtonsoft.Json;
using System.Collections.Generic;
using UapkiNetStandard20.Models.Asn1;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class Asn1DecodeParameters
    {
        [JsonProperty("items")]
        public List<ItemToDecode> Items { get; set; }
    }
}
