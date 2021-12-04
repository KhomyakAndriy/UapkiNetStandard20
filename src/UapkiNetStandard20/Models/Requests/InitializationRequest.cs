using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class InitializationRequest: BaseRequest<InitializationParameters>
    {
        private const string MethodName = "INIT";
        public InitializationRequest() : base(MethodName)
        {
        }

    }
}
