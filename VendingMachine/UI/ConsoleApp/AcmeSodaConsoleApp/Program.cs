using System;
using Fippa.Money.Currencies;

namespace AcmeSodaConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var coin = CurrencyParser<GBP>.Parse("0.10");
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
