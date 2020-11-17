using System;
using System.Collections.Generic;
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
            return
                _productSelectionStrategy
                    .FindProduct(_spirals, selection)
                    .Dispense();
        }

        public bool IsValid(ISelection selection)
        {
            return _productSelectionStrategy.IsValid(_spirals, selection);
        }

        public Tuple<SelectionResult, BaseStockItem> FindStockItem(ISelection selection)
        {
            return _productSelectionStrategy.FindProduct(_spirals, selection);
        }
    }
}
