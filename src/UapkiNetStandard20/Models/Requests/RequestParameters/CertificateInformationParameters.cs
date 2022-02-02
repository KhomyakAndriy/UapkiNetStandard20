using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CertificateInformationParameters: CertificateIdParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
