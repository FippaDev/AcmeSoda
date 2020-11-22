using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IDispenser
    {
        ushort Id { get; }
        StockItem StockItem { get; }

        StockItem Dispense();
        uint StockCount();
        bool AddStockItem(StockItem stockItem);
    }
}