﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class CertificateInformationParameters: CertificateIdParameters
    {
        [JsonProperty("bytes")]
        public string BytesBase64 { get; set; }
    }
}
