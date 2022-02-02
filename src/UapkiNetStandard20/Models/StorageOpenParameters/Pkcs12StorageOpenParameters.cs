using Newtonsoft.Json;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.StorageOpenParameters
{
    public class Pkcs12StorageOpenParameters : IStorageOpenParameters
    {
        [JsonProperty("provider")]
        public string Provider { get; }

        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonProperty("mode")]
        public StorageOpenMode OpenMode { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("openParams")]
        public Pkcs12StorageOpenInnerParameters OpenParameters { get; set; }

        public Pkcs12StorageOpenParameters()
        {
            Provider = "PKCS12";
            OpenParameters = new Pkcs12StorageOpenInnerParameters();
            OpenMode = StorageOpenMode.ReadOnly;
        }
    }

    public class Pkcs12StorageOpenInnerParameters
    {
        [JsonProperty("bagCipher")]
        public string Cipher { get; set; }

        [JsonProperty("bagKdf")]
        public string KeyDerivationFunction { get; set; }

        [JsonProperty("iterations")]
        public int KdfIterations { get; set; }

        [JsonProperty("macAlgo")]
        public string MacAlgorithm { get; set; }

        public Pkcs12StorageOpenInnerParameters()
        {
            Cipher = "1.2.804.2.1.1.1.1.1.1.3";
            KeyDerivationFunction = "1.2.804.2.1.1.1.1.1.2";
            MacAlgorithm = "1.2.804.2.1.1.1.1.2.1";
            KdfIterations = 10000;
        }
    }
}
