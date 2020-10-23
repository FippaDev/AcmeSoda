using Infrastructure;
using Infrastructure.DTOs;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Admin;

namespace VendingMachine.Shared.Services.Factories
{
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly IUserOutput _output;
        private readonly IDataLoader<PriceListDto> _objectSerializer;
        private readonly IVendingMachineLogic _vendingMachineLogic;
        private readonly IAdminModule _adminModule;

        public VendingMachineFactory(
            IUserOutput output,
            IDataLoader<PriceListDto> objectSerializer,
            IVendingMachineLogic vendingMachineLogic,
            IAdminModule adminModule)
        {
            _output = output;
            _objectSerializer = objectSerializer;
            _vendingMachineLogic = vendingMachineLogic;
            _adminModule = adminModule;
        }

        public IVendingMachine BuildVendingMachine(IUserOutput userOutput, string branding, string priceListFilename)
        {
            var vendingMachine =
                new VendingMachine(
                    _output,
                    _objectSerializer,
                    _vendingMachineLogic,
                    _adminModule,
                    branding);
            vendingMachine.LoadPriceList(priceListFilename);
            return vendingMachine;
        }
    }
}
