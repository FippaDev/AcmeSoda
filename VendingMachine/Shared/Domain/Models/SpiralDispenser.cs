using System.Collections.Generic;
using System.Linq;
using Models.Stock;

namespace Models
{
    internal class SpiralDispenser : IDispenser
    {
        public const int MaxCapacity = 10;

        public BaseStockItem StockItem =>
            _spiral.Any()
                ? _spiral.Peek()
                : new NullObjectStockItem();

        private readonly Queue<BaseStockItem> _spiral = new Queue<BaseStockItem>(MaxCapacity);

        public SpiralDispenser()
        {
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
