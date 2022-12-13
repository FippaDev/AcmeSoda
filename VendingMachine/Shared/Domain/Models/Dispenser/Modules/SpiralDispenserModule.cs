using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules;

public class SpiralDispenserModule : AbstractDispenserModule
{
    public SpiralDispenserModule(ISelectionStrategy selectionStrategy)
        : base(selectionStrategy)
    {
    }

    public override void Initialise(ushort[] dimensions)
    {
        ushort rows = dimensions[0];
        ushort columns = dimensions[1];
        ushort depth = dimensions[2];

        Guard.Against.Zero(rows, nameof(rows));
        Guard.Against.Zero(columns, nameof(columns));
        Guard.Against.Zero(depth, nameof(depth));

        for (ushort id = 0; id < rows * columns; id++)
        {
            _holders.Add(new Dispenser(id, depth));
        }
    }

    public override ReadOnlyCollection<StockReportLine> GetStockReport(IStockReporting reportGenerator, PriceList priceList)
    {
        return 
            priceList.Items
                .Select(item => new StockReportLine(0, item.DisplayName, item.RetailPrice, 0))
                .ToList()
                .AsReadOnly();
    }
}