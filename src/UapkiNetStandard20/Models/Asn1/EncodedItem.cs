using Newtonsoft.Json;
using System.Collections.Generic;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Asn1
{
    public class EncodedItem
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

        [JsonProperty("id")]
        public string Id { get; set; }

        public byte[] Bytes { get; set; }

        private string _bytesBase64 { get; set; }
    }

    internal class Asn1EncodedItems
    {
        [JsonProperty("encoded")]
        public List<EncodedItem> Encoded { get; set; }
    }
}
