using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IPriceListService
    {
        PriceList Load(string filename);
    }
}
