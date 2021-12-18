using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class StoragesParameters
    {

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }
}
