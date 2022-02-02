using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Verifying
{
    public class SignatureParameters
    {
        [JsonProperty("signAlgo")]
        public string SignatureAlgorithm { get; set; }
    }
}
