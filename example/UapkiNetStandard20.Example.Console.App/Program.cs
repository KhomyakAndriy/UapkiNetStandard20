using System;
using System.IO;

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
                var init = library.Init("certs/", "certs/crls/", "http://acskidd.gov.ua/services/tsp/", null);
                Console.WriteLine($"Бiблiотека:\t{libraryInfo.Name}\nВерсiя:\t\t{libraryInfo.Version}");
            }
            Console.ReadLine();
        }
    }
}
