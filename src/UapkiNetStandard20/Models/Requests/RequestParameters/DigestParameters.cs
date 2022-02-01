using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class DigestParameters
    {
        [JsonProperty("hashAlgo")]
        public string HashAlgorithm { get; set; }

        [JsonProperty("signAlgo")]
        public string SignAlgorithm { get; set; }

        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }

        [JsonProperty("file")]
        public string FilePath { get; set; }

        [JsonProperty("ptr")]
        public string PointerToMemory { get; set; }

        [JsonProperty("size")]
        public int? PointerToMemorySize { get; set; }
    }
}
