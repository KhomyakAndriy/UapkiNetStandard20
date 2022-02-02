using Newtonsoft.Json;
using System.Collections.Generic;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.Certificate
{
    public class CertificateV3
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

        public byte[] BytesDer { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("issuer")]
        public Dictionary<string, string> Issuer { get; set; }

        [JsonProperty("validity")]
        public ValidityTimeStamp Validity { get; set; }

        [JsonProperty("subject")]
        public Dictionary<string, string> Subject { get; set; }

        [JsonProperty("subjectPublicKeyInfo")]
        public SubjectPublicKeyInformation SubjectPublicKeyInformation { get; set; }

        [JsonProperty("extensions")]
        public List<CertificateExtension> Extensions { get;set; }

        [JsonProperty("signatureInfo")]
        public SignatureInformation SignatureInformation { get; set; }

        [JsonProperty("selfSigned")]
        public bool IsSelfSigned { get; set; }

        private string _bytesBase64;

        public string GetIssuerCommonName()
        {
            return Issuer?["CN"];
        }

        public string GetSubjectCommonName()
        {
            return Subject?["CN"];
        }

        public string GetSubjectSurName()
        {
            return Subject?["SN"];
        }

        public string GetSubjectGivenName()
        {
            return Subject?["G"];
        }
    }
}
