using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Certificate
{
    public class SubjectPublicKeyInformation
    {
        [JsonProperty("bytes")]
        internal string BytesBase64
        {
            get => _bytesBase64;
            set
            {
                _bytesBase64 = value;
                BytesDer = ConvertExtension.FromBase64OrNull(_bytesBase64);
            }
        }

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

        [JsonProperty("publicKey")]
        internal string PublicKeyBase64
        {
            get => _publicKeyBase64;
            set
            {
                _publicKeyBase64 = value;
                PublicKey = ConvertExtension.FromBase64OrNull(_publicKeyBase64);
            }
        }

        public byte[] BytesDer { get; set; }

        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        public byte[] Parameters { get; set; }

        public byte[] PublicKey { get; set; }

        private string _bytesBase64;
        private string _parametersBase64;
        private string _publicKeyBase64;
    }
}
