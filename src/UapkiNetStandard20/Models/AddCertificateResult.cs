using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models
{
    internal class AddCertificateResult
    {
        [JsonProperty("added")]
        public List<CertificateStorageRecord> Certificates { get; set; }
    }


}
