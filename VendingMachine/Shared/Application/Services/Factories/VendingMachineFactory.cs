using Domain.VendingMachine;
using Fippa.IO.Serialization;
using Models.Pricing;
using UserInterface;
using VendingLogic;
using VendingLogic.Admin;

namespace Services.Factories
{
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly IUserOutput _output;
        private readonly IObjectSerializer<PriceList> _objectSerializer;
        private readonly IVendingMachineLogic _vendingMachineLogic;
        private readonly IAdminModule _adminModule;

        public VendingMachineFactory(
            IUserOutput output,
            IObjectSerializer<PriceList> objectSerializer,
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
