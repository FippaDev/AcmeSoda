using Unity;
using Unity.Resolution;
using VendingMachine.Shared.Domain.DomainServices;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.VendingMachine;

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

            var userOutput = _unityContainer.Resolve<IUserOutput>();

            var reporting = _unityContainer.Resolve<IStockReporting>(
                new ParameterOverride("userOutput", userOutput));

            var vendingMachine =
                new VendingMachine(
                    userOutput,
                    _unityContainer.Resolve<IPriceListService>(),
                    _unityContainer.Resolve<IStockLoaderService>(),
                    reporting,
                    logic,
                    branding);

            return vendingMachine;
        }
    }
}
