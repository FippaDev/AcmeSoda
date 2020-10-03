using System.Diagnostics.CodeAnalysis;
using Domain.VendingMachine;
using Services.Factories;
using UserInterface;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IUserInput _input;
        private readonly IUserOutput _output;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IUserInput userInput, IUserOutput userOutput, IVendingMachineFactory factory)
        {
            _input = userInput;
            _output = userOutput;
            _vendingMachine = factory.BuildVendingMachine(userOutput, "Pepsi", "pepsi.json");
            _output.ShowWelcomeMessage(_vendingMachine.Manufacturer);
        }

        public void Run()
        {
            _input.Run(_vendingMachine);
        }
    }
}
