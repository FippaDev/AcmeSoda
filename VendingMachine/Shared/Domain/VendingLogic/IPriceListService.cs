namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IPriceListService
    {
        void Load(string filename);
        decimal PriceLookup(string sku);
    }
}
