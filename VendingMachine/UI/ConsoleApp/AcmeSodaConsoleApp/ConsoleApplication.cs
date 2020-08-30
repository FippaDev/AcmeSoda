using Services;
using Services.Factories;
using VendingLogic.Payments;

namespace AcmeSodaConsoleApp
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly ICommandLineMenu _commandLineMenu;
        private readonly IVendingMachine _vendingMachine;

        public ConsoleApplication(IVendingMachineFactory factory)
        {
            _vendingMachine = factory.BuildVendingMachine("Pepsi", "pepsi.json");
            _vendingMachine.BalanceChanged += OnBalanceChanged;
            _vendingMachine.ItemDispensed += OnItemDispensed;

            _commandLineMenu = new CommandLineMenu(_vendingMachine);
        }

        public void Run()
        {
            System.Console.WriteLine($"ACME Vending Machine ({_vendingMachine.Manufacturer})");
            System.Console.WriteLine("----------------------------");

            var input = System.Console.ReadLine();
            while (!_commandLineMenu.IsExitCommand(input))
            {
                if (_commandLineMenu.IsHelpCommand(input))
                {
                    DisplayHelpInfo();
                }
                else
                {
                    _commandLineMenu.Action(input);
                }

                input = System.Console.ReadLine();
            }
        }

        private static void OnItemDispensed(object sender, ItemDispensedNotificationEvent e)
        {
            System.Console.WriteLine($"NOW DISPENSING: {e.Item}");
        }

        private static void OnBalanceChanged(object sender, BalanceChangedEvent e)
        {
            System.Console.WriteLine($"Balance(2): £{e.Balance}");
        }

        private static void DisplayHelpInfo()
        {
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("  /?, /h, help => to display this help information.");
            System.Console.WriteLine("  q, e, quit, exit => exit the application.");
            System.Console.WriteLine("  b       Show the current balance");
            System.Console.WriteLine("  1.00, 0.50, 0.20, 0.10, 0.5 => Insert £1, 50p, 20p, 10p, 5p");
            System.Console.WriteLine("  a[X]    Make a selection (e.g. a0, a1, etc)");
        }
    }
}
