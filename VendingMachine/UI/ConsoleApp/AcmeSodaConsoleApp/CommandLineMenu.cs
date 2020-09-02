using System;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Money.Currencies;
using Services;
using VendingLogic.Selection;

namespace AcmeSodaConsoleApp
{
    public class CommandLineMenu : ICommandLineMenu
    {
        private readonly IVendingMachine _vendingMachine;

        private static readonly string[] ExitCommands = new[] { "q", "quit", "e", "exit" };
        private static readonly string[] HelpCommands = new[] { "/?", "/h", "help" };

        public CommandLineMenu(IVendingMachine vendingMachine)
        {
            Guard.Against.Null(vendingMachine, nameof(vendingMachine));
            _vendingMachine = vendingMachine;
        }

        public void Action(in string input)
        {
            var cmd = input.ToLower();

            if (cmd == "b")
            {
                ShowBalance();
                return;
            }

            var coin = CurrencyParser<GBP>.Parse(cmd);
            if (coin.GetType() != typeof(NotSupportedPayment))
            {
                _vendingMachine.AddPayment(coin);
                Console.WriteLine($"Inserted {coin}");
                return;
            }

            if (!IsValidSelection(cmd, out var selectionCode))
            {
                Console.WriteLine("Invalid selection");
                return;
            }

            var selectionResult = _vendingMachine.MakeSelection(selectionCode);
            if (selectionResult == SelectionResult.ValidSelection)
            {
                // TODO: await dispensing
            }
            else if (selectionResult == SelectionResult.InsufficientFunds)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else if (selectionResult == SelectionResult.OutOfStock)
            {
                Console.WriteLine("Out of stock");
            }
        }

        private static bool IsValidSelection(string cmd, out ushort selectionCode)
        {
            var cmdPrefix = cmd[0].ToString().ToLower();
            selectionCode = 0;

            return
                cmdPrefix.Equals("a")
                &&
                ushort.TryParse(cmd.Substring(1), out selectionCode);
        }

        public bool IsExitCommand(in string input)
        {
            return ExitCommands.Contains(input.Trim().ToLower());
        }

        public bool IsHelpCommand(in string input)
        {
            return HelpCommands.Contains(input.Trim().ToLower());
        }

        void ICommandLineMenu.DisplayHelpInfo()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  /?, /h, help => to display this help information.");
            Console.WriteLine("  q, e, quit, exit => exit the application.");
            Console.WriteLine("  b       Show the current balance");
            Console.WriteLine("  1.00, 0.50, 0.20, 0.10, 0.5 => Insert £1, 50p, 20p, 10p, 5p");
            Console.WriteLine("  a[X]    Make a selection (e.g. a0, a1, etc)");
        }

        private void ShowBalance()
        {
            Console.WriteLine($"Balance £{_vendingMachine.Balance}");
        }
    }
}