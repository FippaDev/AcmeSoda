using Unity;
using Unity.Resolution;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.VendingLogic;

namespace VendingMachine.Shared.Services.Factories
{
    public class VendingMachineFactory : IVendingMachineFactory
    {
        private readonly IUnityContainer _unityContainer;

        public VendingMachineFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public IVendingMachine BuildVendingMachine(
            IDispenserModule dispenserModule,
            string branding, 
            string priceListFile)
        {
            var priceListService = _unityContainer.Resolve<IPriceListService>();
            priceListService.Load(priceListFile);

            var logic = _unityContainer.Resolve<IVendingMachineLogic>(
                new ParameterOverride("dispenserModule", dispenserModule));

            var vendingMachine =
                new VendingMachine(
                    _unityContainer.Resolve<IUserOutput>(),
                    logic,
                    branding);

            return vendingMachine;
        }
    }
}
