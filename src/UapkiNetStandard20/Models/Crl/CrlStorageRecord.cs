using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Crl
{
    public class CrlStorageRecord
    {
        [JsonProperty("crlId")]
        public string Id { get; set; }

        [JsonProperty("isUnique")]
        public bool IsUnique { get; set; }
    }
}
