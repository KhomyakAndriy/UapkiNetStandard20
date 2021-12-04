using System;
using System.Runtime.InteropServices;

namespace UapkiNetStandard20.Common
{
    internal class Delegates
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr ProcessDelegate(string request);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void JsonFreeDelegate(IntPtr processResult);

        internal ProcessDelegate Process { get; private set; }
        internal JsonFreeDelegate JsonFree { get; private set; }
        public Delegates(IntPtr libraryHandle)
        {
            var processFunction = UnmanagedLibrary.GetFunctionPointer(libraryHandle, "process");
            Process = UnmanagedLibrary.GetDelegateForFunctionPointer<ProcessDelegate>(processFunction);

            var jsonFreeFunction = UnmanagedLibrary.GetFunctionPointer(libraryHandle, "json_free");
            JsonFree = UnmanagedLibrary.GetDelegateForFunctionPointer<JsonFreeDelegate>(jsonFreeFunction);
        }

        public void Clear()
        {
            Process = null;
            JsonFree = null;
        }
    }
}
