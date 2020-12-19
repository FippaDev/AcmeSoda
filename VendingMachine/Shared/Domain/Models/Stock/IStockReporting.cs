using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendingMachine.Shared.Domain.Models.Stock
{
    public interface IStockReporting
    {
        ReadOnlyCollection<string> ShowStockReport(IEnumerable<StockReportLine> stockLines);
    }
}