using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class SpiralDispenserModule : IDispenserModule
    {
        private readonly ISelectionStrategy _selectionStrategy;

        // Key = spiral identifier (e.g. A3)
        // value = spiral
        private readonly List<SpiralDispenser> _spirals;

        public bool IsEmpty => _spirals.All(s => s.StockCount() == 0);

        public SpiralDispenserModule(ISelectionStrategy selectionStrategy, ushort rows, ushort columns, ushort depth)
        {
            _selectionStrategy = selectionStrategy;
            Guard.Against.Null(selectionStrategy, nameof(selectionStrategy));
            Guard.Against.Zero(rows, nameof(rows));
            Guard.Against.Zero(columns, nameof(columns));
            Guard.Against.Zero(depth, nameof(depth));

            _spirals = new List<SpiralDispenser>();
            for (ushort id = 0; id < rows * columns; id++)
            {
                _spirals.Add(new SpiralDispenser(id++, depth));
            }
        }

        public StockItem Dispense(string input)
        {
            var resultAndStockItem = _selectionStrategy.GetDispenser(_spirals, input);
            var selectionResult = resultAndStockItem.Item1;
            var dispenser = resultAndStockItem.Item2;

            Debug.Assert(selectionResult == SelectionResult.ValidSelection);
            return dispenser.Dispense();
        }

        public Tuple<SelectionResult, IDispenser> GetDispenser(string input)
        {
            return _selectionStrategy.GetDispenser(_spirals, input);
        }

        public string GetStockReport()
        {
            var builder = new StringBuilder();
            foreach (var d in _spirals)
            {
                builder.AppendFormat($" {d.Id}:({d.StockItem.StockKeepingUnit}/{d.StockCount()})");
            }

            return builder.ToString().Trim();
        }

        public void Load(IEnumerable<InventoryItem> items)
        {
            foreach (var item in items)
            {
                for (ushort i = 0; i < item.Quantity; i++)
                {
                    _spirals[item.DispenserId].AddStockItem(new StockItem(item.SKU));
                }
            }
        }
    }
}
