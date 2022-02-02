using Newtonsoft.Json;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Certificate
{
    public class SignatureInformation
    {
        [JsonProperty("parameters")]
        internal string ParametersBase64
        {
            get => _parametersBase64;
            set
            {
                _parametersBase64 = value;
                Parameters = ConvertExtension.FromBase64OrNull(_parametersBase64);
            }
        }

        [JsonProperty("signature")]
        internal string SignatureBase64
        {
            get => _signatureBase64;
            set
            {
                _signatureBase64 = value;
                Signature = ConvertExtension.FromBase64OrNull(_signatureBase64);
            }
        }

        public string Algorithm { get; set; }

        public byte[] Parameters { get; set; }

        public byte[] Signature { get; set; }

        private string _parametersBase64;
        private string _signatureBase64;
    }
}
