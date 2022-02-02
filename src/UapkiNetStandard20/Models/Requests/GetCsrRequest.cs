using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class GetCsrRequest: BaseRequest<GetCsrParameters>
    {
        private const string MethodName = "GET_CSR";
        public GetCsrRequest(string signAlgorithm = null) : base(MethodName)
        {
            Parameters = new GetCsrParameters()
            {
                SignAlgorithm = signAlgorithm
            };
        }
    }
}
