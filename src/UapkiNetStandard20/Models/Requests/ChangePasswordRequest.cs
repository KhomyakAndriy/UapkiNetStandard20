namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class ChangePasswordRequest: BaseRequest<ChangePasswordParameters>
    {
        private const string MethodName = "CREATE_KEY";
        public ChangePasswordRequest(string oldPassword, string newPassword) : base(MethodName)
        {
            Parameters = new ChangePasswordParameters()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            };
        }
    }
}
