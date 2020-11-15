using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    internal class SpiralDispenser : IDispenser
    {
        private readonly Queue<BaseStockItem> _spiral;

        public static ushort MaxCapacity { get; private set; }

        public BaseStockItem StockItem =>
            _spiral.Any()
                ? _spiral.Peek()
                : new NullObjectStockItem();

        public SpiralDispenser(ushort depth)
        {
            Guard.Against.Zero(depth, nameof(depth));
            MaxCapacity = depth;
            _spiral = new Queue<BaseStockItem>(MaxCapacity);
        }

        public BaseStockItem Dispense()
        {
            return _spiral.Any() 
                ? _spiral.Dequeue() 
                : new NullObjectStockItem();
        }

        public uint StockCount()
        {
            return (uint)_spiral.Count;
        }

        public bool AddStockItem(BaseStockItem stockItem)
        {
            if (_spiral.Count < MaxCapacity)
            {
                _spiral.Enqueue(stockItem);
                return true;
            }

            return false;
        }
    }
}
