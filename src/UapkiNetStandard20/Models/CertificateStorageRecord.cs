using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models
{
    public class CertificateStorageRecord
    {
        [JsonProperty("certId")]
        public string Id { get; set; }

        [JsonProperty("isUnique")]
        public bool IsUnique { get; set; }
    }
}
