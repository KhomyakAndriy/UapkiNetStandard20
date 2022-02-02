using Newtonsoft.Json;

namespace UapkiNetStandard20.Models
{
    public class Mechanism
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("keyParam")]
        public string[] KeyParameters { get; set; }

        [JsonProperty("signAlgo")]
        public string[] SignAlgorithm { get; set; }
    }
}
