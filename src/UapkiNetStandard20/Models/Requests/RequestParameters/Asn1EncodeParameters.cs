using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Asn1;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class Asn1EncodeParameters
    {
        [JsonProperty("items")]
        public List<ItemToEncode> Items { get; set; }
    }
}
