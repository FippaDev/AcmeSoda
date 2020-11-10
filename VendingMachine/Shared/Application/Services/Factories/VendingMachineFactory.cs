using Infrastructure;
using Infrastructure.DTOs;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.VendingLogic;

namespace VendingMachine.Shared.Services.Factories
{
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly IUserOutput _output;
        private readonly IDataLoader<PriceListDto> _objectSerializer;
        private readonly IVendingMachineLogic _vendingMachineLogic;

        public VendingMachineFactory(
            IUserOutput output,
            IDataLoader<PriceListDto> objectSerializer,
            IVendingMachineLogic vendingMachineLogic)
        {
            _output = output;
            _objectSerializer = objectSerializer;
            _vendingMachineLogic = vendingMachineLogic;
        }

        public IVendingMachine BuildVendingMachine(
            SpiralDispenserModule spiralDispenserModule, 
            string branding,
            string priceListFilename)
        {
            _vendingMachineLogic.With(spiralDispenserModule);

            var vendingMachine =
                new VendingMachine(
                    _output,
                    _objectSerializer,
                    _vendingMachineLogic,
                    branding);
            vendingMachine.LoadPriceList(priceListFilename);
            return vendingMachine;
        }
    }
}
