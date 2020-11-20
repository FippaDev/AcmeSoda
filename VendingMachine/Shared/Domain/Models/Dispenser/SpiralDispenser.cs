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

        public ushort Id { get; }

        public BaseStockItem StockItem =>
            _spiral.Any()
                ? _spiral.Peek()
                : new NullObjectStockItem();

        public SpiralDispenser(ushort id, ushort depth)
        {
            Guard.Against.Negative(id, nameof(id));
            Guard.Against.Zero(depth, nameof(depth));
            Id = id;
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
