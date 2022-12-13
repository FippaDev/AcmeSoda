using System.Collections.ObjectModel;
using System.Linq;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules;

public class DispenserReport : IDispenserReport
{
    private readonly AbstractDispenserModule _abstractDispenserModule;

    public DispenserReport(AbstractDispenserModule abstractDispenserModule)
    {
        _abstractDispenserModule = abstractDispenserModule;
    }

    public ReadOnlyCollection<StockReportLine> GetStockReport(PriceList priceList)
    {
        return
            _abstractDispenserModule._holders
                .Select(d => new
                {
                    d,
                    details = priceList.GetProductDetails(d.StockItem.StockKeepingUnit)
                })
                .Select(t =>
                    new StockReportLine(
                        t.d.Id,
                        t.details.DisplayName,
                        t.details.RetailPrice,
                        t.d.StockCount()))
                .ToList()
                .AsReadOnly();
    }
}