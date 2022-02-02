using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Signing
{
    public class Sign
    {
        [JsonProperty("signParams")]
        public SignParameters SignParameters { get; set; }

        [JsonProperty("dataTbs")]
        public List<DataParameters> DataParameters { get; set; }

        [JsonProperty("keyParams")]
        public KeyParameters KeyParameters { get; set; }
    }
}
