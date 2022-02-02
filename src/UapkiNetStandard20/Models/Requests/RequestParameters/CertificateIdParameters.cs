using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CertificateIdParameters
    {
        [JsonProperty("certId")]
        public string CertificateIdBase64 { get; set; }
    }
}
