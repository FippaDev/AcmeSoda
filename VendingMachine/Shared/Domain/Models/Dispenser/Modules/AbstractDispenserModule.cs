using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules
{
    public abstract class AbstractDispenserModule : IDispenserModule
    {
        private readonly ISelectionStrategy _selectionStrategy;

        // Key = spiral identifier (e.g. A3)
        // value = spiral
        protected internal readonly List<IDispenser> _holders;
        private readonly DispenserReport _dispenserReport;

        public bool IsEmpty => _holders.All(s => s.StockCount() == 0);

        protected AbstractDispenserModule(ISelectionStrategy selectionStrategy)
        {
            _selectionStrategy = selectionStrategy;
            Guard.Against.Null(selectionStrategy, nameof(selectionStrategy));

            _holders = new List<IDispenser>();
            _dispenserReport = new DispenserReport(this);
        }

        public virtual void Initialise(ushort[] dimensions)
        {
        }

        public StockItem Dispense(string input)
        {
            var resultAndStockItem = _selectionStrategy.GetDispenser(_holders, input);
            var selectionResult = resultAndStockItem.Item1;
            var dispenser = resultAndStockItem.Item2;

            Debug.Assert(selectionResult == SelectionResult.ValidSelection);
            return dispenser.Dispense();
        }

        public Tuple<SelectionResult, IDispenser> GetDispenser(string input)
        {
            return _selectionStrategy.GetDispenser(_holders, input);
        }

        public void Load(IEnumerable<InventoryItem> items)
        {
            Debug.Assert(_holders.Count > 0, "No dispensers found. Forgotten to initialise the dispenser module?");

            foreach (var item in items)
            {
                var dispenser = _holders[item.DispenserId];
                dispenser.BulkLoadItems(item.SKU, item.Quantity);
            }
        }

        public IEnumerable<StockReportLine> GetStockReport(PriceList priceList)
        {
            var dispenserReport = new DispenserReport(this);
            return dispenserReport.GetStockReport(priceList);
        }
    }
}
