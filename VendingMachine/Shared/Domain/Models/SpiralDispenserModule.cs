using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Models.Exceptions;
using Models.Stock;

[assembly:InternalsVisibleTo("Models.Tests")]
namespace Models
{
    internal class SpiralDispenserModule : IDispenserModule
    {
        private readonly Dictionary<byte, SpiralDispenser> _spirals;
 
        public SpiralDispenserModule(ushort numberOfSpirals, IList<byte> spiralIdentifiers)
        {
            Guard.Against.Zero(numberOfSpirals, nameof(numberOfSpirals));
            
            _spirals = new Dictionary<byte, SpiralDispenser>();
            
            for (int i = 0; i < numberOfSpirals; i++)
            {
                _spirals.Add(spiralIdentifiers[i], new SpiralDispenser());
            }
        }

        public BaseStockItem Dispense(byte identifier)
        {
            if (!_spirals.ContainsKey(identifier))
            {
                throw new InvalidProductIdentifierException($"Unknown item. Identifier:{identifier}");
            }

            return _spirals[identifier].Dispense();
        }
    }
}
