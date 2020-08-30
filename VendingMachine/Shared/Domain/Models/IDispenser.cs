using Models.Stock;

namespace Models
{
    public interface IDispenser
    {
        BaseStockItem Dispense();
        uint StockCount();
        bool AddStockItem(BaseStockItem stockItem);
    }
}