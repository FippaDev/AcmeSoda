using Fippa.IO.Console;
using Services;
using Services.Factories;
using VendingLogic.Payments;

namespace AcmeSodaConsoleApp
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly IConsole _console;
        private readonly ICommandLineMenu _commandLineMenu;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IConsole console, IVendingMachineFactory factory)
        {
            _console = console;
            _vendingMachine = factory.BuildVendingMachine("Pepsi", "pepsi.json");
            _vendingMachine.BalanceChanged += OnBalanceChanged;
            _vendingMachine.ItemDispensed += OnItemDispensed;

            _commandLineMenu = new CommandLineMenu(console, _vendingMachine);
        }

        public void Run()
        {
            _console.WriteLine($"ACME Vending Machine ({_vendingMachine.Manufacturer})");
            _console.WriteLine("----------------------------");

            var input = System.Console.ReadLine();
            while (!_commandLineMenu.IsExitCommand(input))
            {
                _commandLineMenu.Action(input);
                input = System.Console.ReadLine();
            }
        }

        private void OnItemDispensed(object sender, ItemDispensedNotificationEvent e)
        {
            _console.WriteLine($"NOW DISPENSING: {e.Item.DisplayName}");
        }

        private void OnBalanceChanged(object sender, BalanceChangedEvent e)
        {
            _console.WriteLine($"Balance(2): £{e.Balance}");
        }
    }
}
