using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class SpiralDispenserModule : IDispenserModule
    {
        private readonly IProductSelectionStrategy _productSelectionStrategy;

        // Key = spiral identifier (e.g. A3)
        // value = spiral
        private readonly List<SpiralDispenser> _spirals;

        public SpiralDispenserModule(IProductSelectionStrategy productSelectionStrategy, ushort rows, ushort columns, ushort depth)
        {
            _productSelectionStrategy = productSelectionStrategy;
            Guard.Against.Null(productSelectionStrategy, nameof(productSelectionStrategy));
            Guard.Against.Zero(rows, nameof(rows));
            Guard.Against.Zero(columns, nameof(columns));
            Guard.Against.Zero(depth, nameof(depth));

            _spirals = new List<SpiralDispenser>();
            for (ushort id = 0; id < rows * columns; id++)
            {
                _spirals.Add(new SpiralDispenser(id++, depth));
            }
        }

        public BaseStockItem Dispense(ISelection selection)
        {
            var resultAndStockItem =
                _productSelectionStrategy
                    .ValidateSelection(_spirals, selection);
            var selectionResult = resultAndStockItem.Item1;
            var dispenser = resultAndStockItem.Item2;

            Debug.Assert(selectionResult == SelectionResult.ValidSelection);
            return dispenser.Dispense();
        }

        public Tuple<SelectionResult, IDispenser> ValidateSelection(ISelection selection)
        {
            return _productSelectionStrategy.ValidateSelection(_spirals, selection);
        }
    }
}
