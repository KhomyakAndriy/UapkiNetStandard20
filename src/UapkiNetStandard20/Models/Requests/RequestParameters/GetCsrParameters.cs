using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class GetCsrParameters
    {
        [JsonProperty("signAlgo")]
        public string SignAlgorithm { get; set; }
    }
}
