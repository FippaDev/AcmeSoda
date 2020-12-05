using System.Diagnostics.CodeAnalysis;
using Unity;
using UserInterface;
using VendingMachine.Shared.Domain.Models.Dispenser.Modules;
using VendingMachine.Shared.Domain.Models.VendingMachine;
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
            var dispenserModule = _container.Resolve<SpiralDispenserModule>();
            dispenserModule.Initialise(
                new[]
                {
                    (ushort)3, // rows
                    (ushort)4, // columns,
                    (ushort)15, // depth
                });

            var factory = container.Resolve<IVendingMachineFactory>();
            var branding = "Pepsi";
            _vendingMachine = factory.BuildVendingMachine(dispenserModule, branding);
        }

        public void Run()
        {
            _vendingMachine.LoadPriceList(@"data\pepsi\pepsiPrice.json");
            _vendingMachine.LoadStock(@"data\pepsi\pepsiStock.json");
            _vendingMachine.Initialise();

            var input = _container.Resolve<IUserInput>();
            input.Run(_vendingMachine);
        }
    }
}
