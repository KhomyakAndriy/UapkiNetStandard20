using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Models.Certificate
{
    public class CrlValidationInformation
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("crlId")]
        public string CrlId { get;set; }

        [JsonProperty("statusSignature")]
        public VerificationStatus StatusSignature { get; set; }
    }
}
