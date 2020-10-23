using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;

namespace VendingMachine.Shared.Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(IUserOutput userOutput, string branding, string priceListFile);
    }
}