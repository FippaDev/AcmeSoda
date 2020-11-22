using Unity;
using Unity.Resolution;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
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
            string branding)
        {
            var logic = _unityContainer.Resolve<IVendingMachineLogic>(
                new ParameterOverride("dispenserModule", dispenserModule));

            var inventory = _unityContainer.Resolve<IStockLoaderService>(
                new ParameterOverride("dispenserModule", dispenserModule));

            var vendingMachine =
                new VendingMachine(
                    _unityContainer.Resolve<IUserOutput>(),
                    _unityContainer.Resolve<IPriceListService>(),
                    _unityContainer.Resolve<IStockLoaderService>(),
                    logic,
                    branding);

            return vendingMachine;
        }
    }
}
