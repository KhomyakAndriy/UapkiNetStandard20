using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class SelectKeyRequest: BaseRequest<IdParameters>
    {
        private const string MethodName = "SELECT_KEY";
        public SelectKeyRequest(string id) : base(MethodName)
        {
            Parameters = new IdParameters()
            {
                Id = id
            };
        }
    }
}
