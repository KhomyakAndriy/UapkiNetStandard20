using Newtonsoft.Json;

namespace UapkiNetStandard20.Models.Requests
{
    internal class BaseRequest<T> : BaseRequest
    {
        
        [JsonProperty("parameters")]
        public T Parameters { get; set; }

        public BaseRequest(string methodName) : base(methodName) { }
    }

    internal class BaseRequest
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        private static JsonSerializerSettings _serializationSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public BaseRequest(string methodName)
        {
            Method = methodName;
        }

        public string ToJson()
        {
            Formatting format;
#if DEBUG
            format = Formatting.Indented;
#else
            format = Formatting.None;
#endif
            return JsonConvert.SerializeObject(this, format, _serializationSettings);
        }
    }
}
