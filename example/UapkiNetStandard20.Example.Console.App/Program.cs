using System;
using System.IO;
using System.Linq;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Models.StorageOpenParameters;
using UapkiNetStandard20.Models.Signing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace UapkiNetStandard20.Example.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var osSafePath = Path.Combine(AppContext.BaseDirectory, "libraries", "x64", "uapki.dll");
            using (var library = new UapkiNet(osSafePath, DebugLogger))
            {
                var libraryInfo = library.Version();
                Console.WriteLine($"Бiблiотека:\t\t{libraryInfo.Name}\nВерсiя:\t\t\t{libraryInfo.Version}");

                var init = library.Init();
                var initSuccess = init != null;
                Console.WriteLine($"Запуск:\t\t\t{(initSuccess ? "Успiшний": "Помилка")}");
                if (initSuccess)
                {

                    var providers = library.GetProvidersFullInfo();
                    Console.WriteLine($"Кiлькiсть провайдерiв:\t{providers.Count}");
                    foreach (var provider in providers)
                    {
                        Console.WriteLine($"PROVIDER: {provider.Id} - {provider.Description}");
                        try
                        {
                            string storages = provider.Storages == null ? "[]" :
                                string.Join(", ", provider.Storages.Select(s => s.Id));
                            Console.WriteLine($"STORAGE IDs: {storages}");
                            Console.WriteLine();
                        }
                        catch
                        {
                            // Ignore
                        }

                    }
                    Console.WriteLine($"Вкажiть повний шлях сховища сертифiкатiв (.p7b) або залиште поле пустим:");
                    var p7bPath = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(p7bPath) && File.Exists(p7bPath))
                    {
                        var certificateIds = library.AddCertificates(File.ReadAllBytes("CACertificates.p7b"), true);
                    }

                    Console.WriteLine($"Вкажiть повний шлях сховища PKCS12:");
                    var storageId = Console.ReadLine();
                    Console.WriteLine($"Вкажiть пароль сховища PKCS12:");
                    var password = Console.ReadLine();

                    var storage = library.OpenStorage(new Pkcs12StorageOpenParameters()
                    {
                        Storage = storageId,
                        Password = password
                    });
                    library.SelectKey(storage, 0);
                    var sign = library.Sign(new Sign()
                    {
                        SignParameters = new SignParameters()
                        {
                            Format = SignatureFormat.CadesT,
                            IsDataDetached = true,
                            NeedIncludeCertificate = true,
                            NeedIncludeHostTimestamp = true,
                            Algorithm = "1.2.804.2.1.1.1.1.3.1.1",
                            SignaturePolicy = SignaturePolicy.Default
                        },
                        DataParameters = new List<DataParameters>()
                        {
                            new DataParameters()
                            {
                                Id = "doc-0",
                                BytesBase64 = Convert.ToBase64String(new byte[] { 1, 2, 3 })
                            }
                        }
                    }).First();

                    Console.WriteLine($"{sign.Id}: {sign.BytesBase64}");
                }

            }
            Console.ReadLine();
        }

        static void DebugLogger(LogLevel logLevel, string message, Exception exception = null)
        {
            Debug.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logLevel}]: {message}");
        }
    }
}
