using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Interfaces;

namespace UapkiNetStandard20.Models
{
    internal class StoragesList
    {
        public List<Storage> Storages { get; set; }
    }

    public class Storage
    {
        public string Id { get; set; }

        public string ProviderId { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public string Serial { get; set; }

        public string Label { get; set; }

        public StorageInfo StorageInfo { get; set; }

        public List<KeyInfo> Keys { get; set; }

        public IStorageOpenParameters StorageOpenParameters { get; set; }
    }
}
