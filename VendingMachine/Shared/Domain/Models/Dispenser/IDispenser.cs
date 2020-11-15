using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IDispenser
    {
        BaseStockItem Dispense();
        uint StockCount();
        bool AddStockItem(BaseStockItem stockItem);
    }
}