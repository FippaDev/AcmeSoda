using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.Models.Dispenser;

namespace VendingMachine.Shared.Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(IDispenserModule dispenserModule, string branding, string pepsiJson);
    }
}