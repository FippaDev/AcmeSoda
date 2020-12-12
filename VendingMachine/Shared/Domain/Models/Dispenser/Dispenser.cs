using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class Dispenser : IDispenser
    {
        private readonly Queue<StockItem> _holder;

        public static ushort MaxCapacity { get; private set; }

        public ushort Id { get; }

        public StockItem StockItem =>
            _holder.Any()
                ? _holder.Peek()
                : new NullObjectStockItem();

        public Dispenser(ushort id, ushort capacity)
        {
            Guard.Against.Negative(id, nameof(id));
            Guard.Against.Zero(capacity, nameof(capacity));
            Id = id;
            MaxCapacity = capacity;
            _holder = new Queue<StockItem>(MaxCapacity);
        }

        public StockItem Dispense()
        {
            return _holder.Any()
                ? _holder.Dequeue()
                : new NullObjectStockItem();
        }

        public ushort StockCount()
        {
            return (ushort)_holder.Count;
        }

        public bool AddStockItem(StockItem stockItem)
        {
            if (_holder.Count < MaxCapacity)
            {
                _holder.Enqueue(stockItem);
                return true;
            }

            return false;
        }

        public void BulkLoadItems(in string sku, in ushort quantity)
        {
            for (ushort i = 0; i < quantity; i++)
            {
                AddStockItem(new StockItem(sku));
            }
        }
    }
}
