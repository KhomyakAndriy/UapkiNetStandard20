using Newtonsoft.Json;
using System;

namespace UapkiNetStandard20.Models.Certificate
{
    public class ValidityTimeStamp
    {
        [JsonProperty("notBefore")]
        public DateTime NotBefore { get; set; }

        [JsonProperty("notAfter")]
        public DateTime NotAfter { get; set; }
    }
}
