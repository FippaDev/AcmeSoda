using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.VendingMachine;

namespace VendingMachine.Shared.Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(IDispenserModule dispenserModule, string branding);
    }
}