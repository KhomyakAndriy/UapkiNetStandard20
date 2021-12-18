using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class StorageInfoRequest: BaseRequest<StorageInfoParameters>
    {
        private const string MethodName = "STORAGE_INFO";
        public StorageInfoRequest(string providerId, string storageId) : base(MethodName)
        {
            Parameters = new StorageInfoParameters()
            {
                Provider = providerId,
                Storage = storageId
            };
        }
    }
}
