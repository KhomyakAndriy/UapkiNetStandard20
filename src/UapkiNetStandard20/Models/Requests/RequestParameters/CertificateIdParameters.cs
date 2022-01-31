using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CertificateIdParameters
    {
        [JsonProperty("certId")]
        public string CertificateIdBase64 { get; set; }
    }
}
