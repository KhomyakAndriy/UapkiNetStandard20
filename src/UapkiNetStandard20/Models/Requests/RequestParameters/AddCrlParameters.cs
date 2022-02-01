using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class AddCrlParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }

        [JsonProperty("permanent")]
        public bool Permanent { get; set; }
    }
}
