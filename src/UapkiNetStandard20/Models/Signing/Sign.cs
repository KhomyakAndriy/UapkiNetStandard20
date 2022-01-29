using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Signing
{
    public class Sign
    {
        [JsonProperty("signParams")]
        public SignParameters SignParameters { get; set; }

        [JsonProperty("dataTbs")]
        public DataParameters DataParameters { get; set; }

        [JsonProperty("keyParams")]
        public KeyParameters KeyParameters { get; set; }
    }
}
