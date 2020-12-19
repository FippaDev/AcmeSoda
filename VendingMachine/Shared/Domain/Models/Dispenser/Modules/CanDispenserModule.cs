using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules
{
    public class CanDispenserModule : AbstractDispenserModule
    {
        public CanDispenserModule(ISelectionStrategy selectionStrategy)
            : base(selectionStrategy)
        {
        }

        public override void Initialise(ushort[] dimensions)
        {
            ushort numberOfHolders = dimensions[0];
            ushort capacityPerHolder = dimensions[1];

            Guard.Against.Zero(numberOfHolders, nameof(numberOfHolders));
            Guard.Against.Zero(capacityPerHolder, nameof(capacityPerHolder));

            for (ushort id = 0; id < numberOfHolders; id++)
            {
                _holders.Add(new Dispenser(id++, capacityPerHolder));
            }
        }

        public override ReadOnlyCollection<StockReportLine> GetStockReport(IStockReporting reportGenerator, PriceList priceList)
        {
            var report = new List<StockReportLine>();
            foreach (var item in priceList.Items)
            {
                var qtyInAllHolders = (ushort)_holders
                    .Where(h => h.StockItem.StockKeepingUnit.Equals(item.StockKeepingUnit))
                    .Sum(h => h.StockCount());

                report.Add(new StockReportLine(0, item.DisplayName, item.RetailPrice, qtyInAllHolders));
            }

            return report.AsReadOnly();
        }
    }
}
