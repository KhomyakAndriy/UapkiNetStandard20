using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;
using UapkiNetStandard20.Utils;

namespace UapkiNetStandard20.Models.StorageOpenParameters
{
    public class Pkcs12StorageOpenParameters : IStorageOpenParameters
    {
        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonIgnore]
        public StorageOpenMode OpenMode 
        { 
            get => _openMode;
            set
            {
                _openMode = value;
                _mode = _openMode.GetDescription();
            }
        }

        [JsonProperty("mode")]
        public string UapkiMode => _mode;

        [JsonProperty("otherParams")]
        public Pkcs12StorageOpenInnerParameters OtherParameters { get; set; }

        private string _mode;
        private StorageOpenMode _openMode;
    }

    public class Pkcs12StorageOpenInnerParameters
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("bagCipher")]
        public string Cipher { get; set; }

        [JsonProperty("bagKdf")]
        public string KeyDerivationFunction { get; set; }

        [JsonProperty("iterations")]
        public string KdfIterations { get; set; }

        [JsonProperty("macAlgo")]
        public string MacAlgorithm { get; set; }
    }
}
