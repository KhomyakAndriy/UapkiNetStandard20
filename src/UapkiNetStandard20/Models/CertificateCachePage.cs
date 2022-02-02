using Newtonsoft.Json;
using System.Collections.Generic;

namespace UapkiNetStandard20.Models
{
    public class CertificateCachePage
    {
        [JsonProperty("certIds")]
        public List<string> Ids { get; set; }

        [JsonProperty("count")]
        public int TotalCount { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}
