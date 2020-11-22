using System.Diagnostics.CodeAnalysis;
using Unity;
using Unity.Resolution;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IUnityContainer _container;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IUnityContainer container)
        {
            _container = container;
            var dispenserModule = _container.Resolve<SpiralDispenserModule>(
                new ParameterOverride("rows", (ushort)5),
                new ParameterOverride("columns", (ushort)8),
                new ParameterOverride("depth", (ushort)15));

            var factory = container.Resolve<IVendingMachineFactory>();
            var branding = "Pepsi";
            _vendingMachine = factory.BuildVendingMachine(dispenserModule, branding);
        }

        public void Run()
        {
            _vendingMachine.LoadStock("pepsiStock.json");
            _vendingMachine.LoadPriceList("pepsi.json");

            var input = _container.Resolve<IUserInput>();
            input.Run(_vendingMachine);
            _vendingMachine.Initialise();
        }
    }
}
