using VendingMachine.Shared.Domain.Domain.VendingMachine;

namespace VendingMachine.Shared.Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(string branding, string priceListFile);
    }
}