using System;
using System.IO;
using System.Linq;
using UapkiNetStandard20.Enums;
using UapkiNetStandard20.Models.StorageOpenParameters;

namespace UapkiNetStandard20.Example.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var osSafePath = Path.Combine(AppContext.BaseDirectory, "libraries", "x64", "uapki.dll");
            using (var library = new UapkiNet(osSafePath))
            {
                var libraryInfo = library.Version();
                Console.WriteLine($"Бiблiотека:\t\t{libraryInfo.Name}\nВерсiя:\t\t\t{libraryInfo.Version}");

                var init = library.Init("certs/", "certs/crls/", "http://acskidd.gov.ua/services/tsp/", null);
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

                    Console.WriteLine($"Вкажіть повний шлях сховища PKCS12:");
                    var storageId = Console.ReadLine();
                    Console.WriteLine($"Вкажіть пароль сховища PKCS12:");
                    var password = Console.ReadLine();

                    var storage = library.OpenStorage(new Pkcs12StorageOpenParameters()
                    {
                        Storage = storageId,
                        Password = password,
                    });
                    library.SelectKey(storage, 1);
                }

            }
            Console.ReadLine();
        }
    }
}
