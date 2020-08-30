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
                _vendingMachine?.AddPayment(coin);
                //Console.WriteLine($"Inserted {coin}");
                return;
            }

            if (!IsValidSelection(cmd, out var selectionCode))
            {
                System.Console.WriteLine("Invalid selection");
                return;
            }

            var selectionResult = _vendingMachine?.MakeSelection(selectionCode);
            if (selectionResult == SelectionResult.ValidSelection)
            {
                // TODO: await dispensing
            }
            else if (selectionResult == SelectionResult.InsufficientFunds)
            {
                System.Console.WriteLine("Insufficient funds.");
            }
            else if (selectionResult == SelectionResult.OutOfStock)
            {
                System.Console.WriteLine("Out of stock");
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

        private void ShowBalance()
        {
            System.Console.WriteLine($"Balance £{_vendingMachine.Balance}");
        }
    }
}