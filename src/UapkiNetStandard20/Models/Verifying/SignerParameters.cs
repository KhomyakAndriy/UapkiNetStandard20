using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Verifying
{
    public class SignerParameters
    {
        [JsonProperty("certificate")]
        public string CertificateBase64 { get; set; }

        [JsonProperty("certId")]
        public string CertificateIdBase64 { get; set; }

        [JsonProperty("spki")]
        public object SubjectPublicKeyInfo { get; set; }
    }
}
