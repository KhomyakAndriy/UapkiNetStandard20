using Newtonsoft.Json;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Certificate
{
    public class CertificateExtension
    {
        [JsonProperty("extnValue")]
        internal string ValueBase64
        {
            get => _valueBase64;
            set
            {
                _valueBase64 = value;
                Value = ConvertExtension.FromBase64OrNull(_valueBase64);
            }
        }

        [JsonProperty("extnId")]
        public string Id { get; set; }

        [JsonProperty("critical")]
        public bool IsCritical { get; set; }

        public byte[] Value { get; set; }

        [JsonProperty("decoded")]
        public DecodedExtensionInformation DecodedExtensionInformation { get; set; }

        private string _valueBase64;
    }
}
