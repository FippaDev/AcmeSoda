using System.Collections.Generic;
using Fippa.IO.Console;
using Fippa.Money.Formatters;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Services;

namespace AcmeSodaConsoleApp.StockReport
{
    public class ConsoleStockReporting : IStockReporting
    {
        private readonly IConsole _console;

        public ConsoleStockReporting(IConsole console)
        {
            _console = console;
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
