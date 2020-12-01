using System.Collections.Generic;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Services
{
    public interface IStockReporting
    {
        void ShowStockReport(IEnumerable<StockReportLine> stockLines);
    }
}