using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Verifying
{
    public class SignatureData
    {
        [JsonProperty("bytes")]
        public string SignedDataBase64 { get; set; }

        [JsonProperty("content")]
        public string OriginalDataBase64 { get; set; }

        [JsonProperty("isDigest")]
        public bool IsDigest { get; set; }
    }
}
