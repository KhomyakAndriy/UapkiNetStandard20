using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Interfaces
{
    public interface IStorageOpenParameters
    {
        string Provider { get; }
        string Storage { get; set; }
        StorageOpenMode OpenMode { get; set; }
    }
}
