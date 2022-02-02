using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models.Requests
{
    internal class OpenStorageRequest : BaseRequest<IStorageOpenParameters>
    {
        private const string MethodName = "OPEN";
        public OpenStorageRequest(IStorageOpenParameters storageOpenParameters) : base(MethodName)
        {
            Parameters = storageOpenParameters;
        }
    }
}
