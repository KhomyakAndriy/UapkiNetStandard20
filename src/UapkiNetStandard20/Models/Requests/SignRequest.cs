using UapkiNetStandard20.Models.Signing;

namespace UapkiNetStandard20.Models.Requests
{
    internal class SignRequest: BaseRequest<Sign>
    {
        private const string MethodName = "SIGN";
        public SignRequest(Sign parameters) : base(MethodName)
        {
            Parameters = parameters;
        }
    }
}
