using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class GetCsrParameters
    {
        [JsonProperty("signAlgo")]
        public string SignAlgorithm { get; set; }
    }
}
