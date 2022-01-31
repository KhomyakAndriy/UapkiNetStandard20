using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CertificateInformationParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }

        [JsonProperty("certId")]
        public string CertificateIdBase64 { get; set; }
    }
}
