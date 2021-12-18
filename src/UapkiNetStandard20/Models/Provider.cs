using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models
{
    internal class ProvidersList
    {
        public List<Provider> Providers { get; set; }
    }

    public class Provider
    {
        public string Id { get; set; }

        public string ApiVersion { get; set; }

        [JsonProperty("libVersion")]
        public string LibraryVersion { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string SupportListStorages { get; set; }

        public List<Storage> Storages { get; set; }
    }
}
