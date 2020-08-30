using System.Collections.Generic;
using System.Linq;
using Models.Stock;

namespace Models
{
    internal class SpiralDispenser : IDispenser
    {
        public const int MaxCapacity = 10;

        private readonly Queue<BaseStockItem> _stock;

        public SpiralDispenser()
        {
            _stock = new Queue<BaseStockItem>(MaxCapacity);
        }

        public BaseStockItem Dispense()
        {
            return _stock.Any() 
                ? _stock.Dequeue() 
                : new NullObjectStockItem();
        }

        public uint StockCount()
        {
            return (uint)_stock.Count;
        }

        public bool AddStockItem(BaseStockItem stockItem)
        {
            if (_stock.Count < MaxCapacity)
            {
                _stock.Enqueue(stockItem);
                return true;
            }

            return false;
        }
    }
}
