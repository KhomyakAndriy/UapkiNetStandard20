using System;
using System.Collections.Generic;
using System.Text;
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
