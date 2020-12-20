using System.Collections.Generic;

namespace VendingMachine.Shared.Domain.Models.Stock
{
    public interface IStockReporting
    {
        object GeneratCreateReport(IEnumerable<StockReportLine> stockLines);
    }
}