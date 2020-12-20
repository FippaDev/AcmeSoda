using System.Collections.Generic;

namespace VendingMachine.Shared.Domain.Models.Stock
{
    public interface IStockReporting
    {
        object CreateReport(IEnumerable<StockReportLine> stockLines);
    }
}