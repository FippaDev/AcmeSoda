using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Fippa.IO.Console;
using Fippa.Money.Formatters;
using UserInterface;
using VendingMachine.Shared.Domain.Models.Stock;

namespace AcmeSodaConsoleApp
{
    public class ConsoleOutput : IUserOutput
    {
        private readonly IConsole _console;

        public ConsoleOutput(IConsole console)
        {
            _console = console;
        }

        public void ShowBalance(decimal balance)
        {
            var regionInfo = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Balance {regionInfo.CurrencySymbol}{balance}");
        }

        public void ShowWelcomeMessage(string manufacturer)
        {
            _console.WriteLine($"ACME Vending Machine ({manufacturer})");
            _console.WriteLine("----------------------------");
        }

        public void Message(string message)
        {
            _console.WriteLine(message);
        }

        public void ShowStockReport(IEnumerable<StockReportLine> stockLines)
        {
            _console.WriteLine("----------------------------");
            foreach (var line in stockLines)
            {
                _console.WriteLine(
                    $"{line.DispenserId} {line.DisplayName} {line.Price.DisplayAsCurrency()} {line.StockLevel}");
            }

            _console.WriteLine("----------------------------");
        }
    }
}
