using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Stock;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models
{
    public class SpiralDispenserModule : IDispenserModule
    {
        // Key = spiral identifier (e.g. A3)
        // value = spiral
        private readonly Dictionary<string, SpiralDispenser> _spirals;

        public SpiralDispenserModule(int rows, int columns)
        {
            Guard.Against.Zero(rows, nameof(rows));
            Guard.Against.Zero(columns, nameof(columns));

            _spirals = new Dictionary<string, SpiralDispenser>();
            for (ushort r = 0; r < rows; r++)
            {
                for (ushort c = 1; c <= columns; c++)
                {
                    string id = $"{'A' + r}{c}";
                    _spirals.Add(id, new SpiralDispenser());
                }
            }
        }

        public ReadOnlyCollection<string> GetSelectionCodes()
        {
            return _spirals.Keys.ToList().AsReadOnly();
        }

        public BaseStockItem QuerySpiral(string selectionCode)
        {
            return 
                _spirals[selectionCode].StockItem is PriceListStockItem 
                    ? _spirals[selectionCode].StockItem
                    : new NullObjectStockItem();
        }

        public BaseStockItem Dispense(string selectionCode)
        {
            if (!_spirals.ContainsKey(selectionCode))
            {
                throw new ArgumentException($"Selection code '{selectionCode}' does not exist.");
            }

            return _spirals[selectionCode].Dispense();
        }

        public bool IsValidSelectionCode(string selectionCode)
        {
            Guard.Against.NullOrWhiteSpace(selectionCode, nameof(selectionCode));
            return _spirals.ContainsKey(selectionCode);
        }
    }
}
