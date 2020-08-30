using Models.Stock;

namespace Models
{
    public interface IDispenserModule
    {
        BaseStockItem Dispense(byte identifier);
    }
}