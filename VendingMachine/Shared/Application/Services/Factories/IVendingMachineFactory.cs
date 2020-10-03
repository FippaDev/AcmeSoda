using Domain.VendingMachine;
using UserInterface;

namespace Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(IUserOutput userOutput, string branding, string priceListFile);
    }
}