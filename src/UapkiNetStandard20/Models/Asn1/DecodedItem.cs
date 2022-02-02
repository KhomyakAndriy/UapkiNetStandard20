using Newtonsoft.Json;
using System.Collections.Generic;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Asn1
{
    public class DecodedItem
    {
        [JsonProperty("bytes")]
        internal string BytesBase64 
        {
            get => _bytesBase64; 
            set
            {
                _bytesBase64 = value;
                Bytes = ConvertExtension.FromBase64OrNull(_bytesBase64);
            }
        }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("integer")]
        public int Integer { get; set; }

        public byte[] Bytes { get; set; }

        private string _bytesBase64 { get; set; }
    }

    internal class Asn1DecodedItems
    {
        [JsonProperty("decoded")]
        public List<DecodedItem> Decoded { get; set; }
    }
}
