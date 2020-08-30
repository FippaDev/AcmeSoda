using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Models.Pricing;
using VendingLogic;
using VendingLogic.Admin;

namespace Services.Factories
{
    // No need to include factories in the unit test coverage. There is no logic in here.
    [ExcludeFromCodeCoverage]
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly IObjectSerializer<PriceList> _objectSerializer;
        private readonly IVendingMachineLogic _vendingMachineLogic;
        private readonly IAdminModule _adminModule;

        public VendingMachineFactory(
            IObjectSerializer<PriceList> objectSerializer,
            IVendingMachineLogic vendingMachineLogic,
            IAdminModule adminModule)
        {
            _objectSerializer = objectSerializer;
            _vendingMachineLogic = vendingMachineLogic;
            _adminModule = adminModule;
        }

        public IVendingMachine BuildVendingMachine(string branding, string priceListFilename)
        {
            var vendingMachine = 
                new VendingMachine(
                    _objectSerializer, 
                    _vendingMachineLogic, 
                    _adminModule,
                    branding);
            vendingMachine.LoadPriceList(priceListFilename);
            return vendingMachine;
        }
    }
}
