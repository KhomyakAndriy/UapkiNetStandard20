using System;
using System.Collections.Generic;
using System.Linq;
using UapkiNetStandard20.Interfaces;
using UapkiNetStandard20.Models.Signing;

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

        public List<Mechanism> Mechanisms { get; set; }

        public bool UserPresense { get; set; }

        public IStorageOpenParameters StorageOpenParameters { get; set; }

        private UapkiNet _parentLibrary;

        internal void SetParentLibrary(UapkiNet parentLibrary)
        {
            _parentLibrary = parentLibrary;
        }

        public string CreateKey(int? mechanismIndex = null, string parameter = null, string label = null)
        {
            var mechanismId = mechanismIndex == null ? null : Mechanisms[mechanismIndex.Value].Id;
            var id = _parentLibrary?.CreateKey(mechanismId, parameter, label);
            return id;
        }        

        public void ReloadKeyList()
        {
            var prevSelected = Keys.FirstOrDefault(f => f.IsSelected)?.Id;
            Keys = _parentLibrary.GetOpenedStorageKeys();
            
            if (prevSelected != null)
            {
                var key = Keys.FirstOrDefault(f => f.Id == prevSelected);
                if (key != null)
                {
                    key.IsSelected = true;
                }
            }
        }

        public byte[] GenerateCertificateSigningRequest(string signAlgorithm = null)
        {
            if (string.IsNullOrWhiteSpace(signAlgorithm))
                return GenerateCertificateSigningRequest((int?)null);

            var signAlgorithmIndex = Keys.First(f => f.IsSelected).SigningAlgorithms.FindIndex(alg => alg.Equals(signAlgorithm));
            if (signAlgorithmIndex == -1)
                throw new ArgumentException($"Selected key has no sign algorithm \"{signAlgorithm}\"", nameof(signAlgorithm));

            return GenerateCertificateSigningRequest(signAlgorithmIndex);
        }

        public byte[] GenerateCertificateSigningRequest(int? signAlgorithmIndex = null)
        {
            var signAlgorithm = signAlgorithmIndex.HasValue ?
                Keys.First(f => f.IsSelected).SigningAlgorithms[signAlgorithmIndex.Value] :
                null;

            return _parentLibrary.GenerateCertificateSigningRequest(signAlgorithm);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            _parentLibrary.ChangePassword(oldPassword, newPassword);
        }

        public object InitKeyUsage(object parameters)
        {
            return _parentLibrary.InitKeyUsage(parameters);
        }

        public List<SignatureResult> Sign(Sign sign)
        {
            return _parentLibrary.Sign(sign);
        }
    }
}
