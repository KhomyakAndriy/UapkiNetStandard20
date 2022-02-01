using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class ListCertificatesParameters
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }
    }
}
