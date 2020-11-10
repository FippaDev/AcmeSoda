using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;

namespace VendingMachine.Shared.Services.Factories
{
    public interface IVendingMachineFactory
    {
        IVendingMachine BuildVendingMachine(
            SpiralDispenserModule spiralDispenserModule, 
            string branding,
            string priceListFile);
    }
}