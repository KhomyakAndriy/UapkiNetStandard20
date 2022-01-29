using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Verifying
{
    public class SignatureParameters
    {
        [JsonProperty("signAlgo")]
        public string SignatureAlgorithm { get; set; }
    }
}
