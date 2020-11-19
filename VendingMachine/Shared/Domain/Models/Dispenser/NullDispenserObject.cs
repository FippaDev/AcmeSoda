using System;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class NullDispenserObject : IDispenser
    {
        public ushort Id => 0;

        public BaseStockItem StockItem => new NullObjectStockItem();

        public BaseStockItem Dispense()
        {
            throw new NotImplementedException();
        }

        public uint StockCount()
        {
            throw new NotImplementedException();
        }

        public bool AddStockItem(BaseStockItem stockItem)
        {
            throw new NotImplementedException();
        }
    }
}
