using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UapkiNetStandard20.Enums
{
    public enum  StorageOpenMode
    {
        [Description("RW")]
        ReadWrite,

        [Description("RO")]
        ReadOnly,

        [Description("CREATE")]
        Create
    }
}
