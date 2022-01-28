using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class IdParameters
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
