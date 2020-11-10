using System.Diagnostics.CodeAnalysis;
using AcmeSodaConsoleApp.DependencyInjection;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IUserInput _input;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IUserInput userInput, IUserOutput userOutput, IVendingMachineFactory factory)
        {
            var dispenserModule = DIContainer.Instance.Unity.Resolve<SpiralDispenserModule>(
                new ResolverOverride[]
                {
                    new ParameterOverride("rows", 3),
                    new ParameterOverride("columns", 4)
                });

            _input = userInput;
            _vendingMachine = factory.BuildVendingMachine(
                dispenserModule,
                "Pepsi", 
                "pepsi.json");

            userOutput.ShowWelcomeMessage(_vendingMachine.Manufacturer);
        }

        public void Run()
        {
            _input.Run(_vendingMachine);
        }
    }
}
