using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Signing
{
    public class KeyParameters
    {
        [JsonProperty("permission")]
        public string PermissionBase64 { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonProperty("keyId")]
        public string KeyId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
