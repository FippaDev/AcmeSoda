using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fippa.Money.Formatters;
using VendingMachine.Shared.Domain.Models.Stock;

namespace AcmeSodaConsoleApp.StockReport
{
    public class ConsoleStockReporting : IStockReporting
    {
        public ConsoleStockReporting()
        {
        }

        public ReadOnlyCollection<string> ShowStockReport(IEnumerable<StockReportLine> stockLines)
        {
            var lines = new List<string>();
            lines.Add("----------------------------");
            lines.AddRange(stockLines.Select(line => $"{line.DispenserId} {line.DisplayName} {line.Price.DisplayAsCurrency()} {line.StockLevel}"));
            lines.Add("----------------------------");
            return lines.AsReadOnly();
        }
    }
}
