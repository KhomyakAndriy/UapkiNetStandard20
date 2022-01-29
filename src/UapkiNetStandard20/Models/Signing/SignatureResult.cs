using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Signing
{
    public class SignatureResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
