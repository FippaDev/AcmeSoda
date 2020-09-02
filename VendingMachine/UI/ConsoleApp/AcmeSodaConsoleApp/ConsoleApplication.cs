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
                    _commandLineMenu.DisplayHelpInfo();
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
    }
}
