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
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mechanismId")]
        public string MechanismId { get; set; }

        [JsonProperty("parameterId")]
        public string ParameterId { get; set; }

        [JsonProperty("signAlgo")]
        public List<string> SigningAlgorithms { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public string CertificateId { get; set; }

        public byte[] Certificate { get; set; }

        public bool IsSelected { get; internal set; }

        private UapkiNet _parentLibrary;

        internal void SetParentLibrary(UapkiNet parentLibrary)
        {
            _parentLibrary = parentLibrary;
        }

        public void SelectThisKey()
        {
            _parentLibrary.SelectKey(this);
        }

        public void DeleteKey()
        {
            _parentLibrary.DeleteKey(Id);
        }
    }
}
