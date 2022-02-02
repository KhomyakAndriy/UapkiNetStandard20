using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models.Signing
{
    public class DataParameters
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }

        [JsonProperty("isDigest")]
        public bool IsDigest { get; set; }

        [JsonProperty("signedAttributes")]
        public List<AttributeParameters> SignedPartAttributes { get; set; }

        [JsonProperty("unsignedAttributes")]
        public List<AttributeParameters> UnsignedPartAttributes { get; set; }
    }
}
