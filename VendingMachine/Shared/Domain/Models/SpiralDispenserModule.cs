using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Models.Exceptions;
using Models.Stock;

[assembly:InternalsVisibleTo("Models.Tests")]
namespace Models
{
    internal class SpiralDispenserModule : IDispenserModule
    {
        private readonly Dictionary<byte, SpiralDispenser> _spirals;

        private readonly ushort MinSelectionCode = 1;
        private readonly ushort MaxSelectionCode = 20;

        ushort IDispenserModule.MaxSelectionCode => MaxSelectionCode;
        ushort IDispenserModule.MinSelectionCode => MinSelectionCode;

        public SpiralDispenserModule(ushort numberOfSpirals, IList<byte> spiralIdentifiers)
        {
            Guard.Against.Zero(numberOfSpirals, nameof(numberOfSpirals));
            
            _spirals = new Dictionary<byte, SpiralDispenser>();
            
            for (int i = 0; i < numberOfSpirals; i++)
            {
                _spirals.Add(spiralIdentifiers[i], new SpiralDispenser());
            }
        }

        public string GetStockKeepingUnitCode(ushort selectionCode)
        {
            byte sprialIndex = GetSpiralIndex(selectionCode);
            return _spirals[sprialIndex].StockItem.StockKeepingUnit;
        }

        // Map the selection code to a spiral (e.g. selection 1 = spiral 0)
        // This is can be done with a simple subtraction and cast, but could be mapped.
        private byte GetSpiralIndex(ushort selectionCode)
        {
            return (byte)(selectionCode - 1);
        }

        public BaseStockItem Dispense(byte identifier)
        {
            if (!_spirals.ContainsKey(identifier))
            {
                throw new InvalidProductIdentifierException($"Unknown item. Identifier:{identifier}");
            }

            return _spirals[identifier].Dispense();
        }

        public bool IsValidSelectionCode(ushort selectionCode)
        {
            return selectionCode >= MinSelectionCode && selectionCode <= MaxSelectionCode;
        }
    }
}
