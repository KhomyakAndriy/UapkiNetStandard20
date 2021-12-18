using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models
{
    internal class KeysList
    {
        public List<KeyInfo> Keys { get; set; }
    }

    internal class SelectedKeyInfo
    {
        [JsonProperty("signAlgo")]
        public List<string> SigningAlgorithms { get; set; }

        [JsonProperty("certId")]
        public string CertificateId { get; set; }

        [JsonProperty("cert")]
        public string CertificateBase64 { get; set; }
    }

    public class KeyInfo
    {
        public string Id { get; set; }

        public string MechanismId { get; set; }

        public string ParameterId { get; set; }

        [JsonProperty("signAlgo")]
        public List<string> SigningAlgorithms { get; set; }

        public string Label { get; set; }

        public string CertificateId { get; set; }

        public byte[] Certificate { get; set; }
    }
}
