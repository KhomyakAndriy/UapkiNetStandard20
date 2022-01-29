using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Signing
{
    public class SigningResponse
    {
        [JsonProperty("signatures")]
        public List<SignatureResult> Signatures { get; set; }
    }
}
