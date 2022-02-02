using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Signing
{
    public class SigningResponse
    {
        [JsonProperty("signatures")]
        public List<SignatureResult> Signatures { get; set; }
    }
}
