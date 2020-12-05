using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.DomainServices
{
    public interface IPriceListService
    {
        PriceList Load(string filename);
    }
}
