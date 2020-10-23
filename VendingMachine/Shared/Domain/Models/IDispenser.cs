using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models
{
    public interface IDispenser
    {
        BaseStockItem Dispense();
        uint StockCount();
        bool AddStockItem(BaseStockItem stockItem);
    }
}