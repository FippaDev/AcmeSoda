using System.Collections.ObjectModel;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules
{
    public interface IDispenserReport
    {
        ReadOnlyCollection<StockReportLine> GetStockReport(PriceList priceList);
    }
}