using System;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser;

public class NullDispenserObject : IDispenser
{
    public ushort Id => 0;

    public StockItem StockItem => new NullObjectStockItem();

    public StockItem Dispense()
    {
        throw new NotImplementedException();
    }

    public ushort StockCount()
    {
        throw new NotImplementedException();
    }

    public bool AddStockItem(StockItem stockItem)
    {
        throw new NotImplementedException();
    }

    public void BulkLoadItems(in string itemSku, in ushort itemQuantity)
    {
        throw new NotImplementedException();
    }
}