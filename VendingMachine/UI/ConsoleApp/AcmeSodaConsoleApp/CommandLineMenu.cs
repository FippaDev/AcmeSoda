using System.Globalization;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.IO.Console;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Services;
using VendingLogic.Payments;
using VendingLogic.Selection;

namespace AcmeSodaConsoleApp
{
    public class CommandLineMenu : ICommandLineMenu
    {
        private readonly IConsole _console;
        private readonly IVendingMachine _vendingMachine;

        private static readonly string[] ExitCommands = { "q", "quit", "e", "exit" };
        private static readonly string[] HelpCommands = { "/?", "/h", "help" };

        public CommandLineMenu(IConsole console, IVendingMachine vendingMachine)
        {
            Guard.Against.Null(vendingMachine, nameof(vendingMachine));
            _vendingMachine = vendingMachine;
            _vendingMachine.ItemDispensed += OnItemDispensed;
            Guard.Against.Null(console, nameof(console));
            _console = console;
        }

        private void OnItemDispensed(object sender, ItemDispensedNotificationEvent e)
        {
            _console.WriteLine("Item dispensed");
        }

        public void Action(in string input)
        {
            var cmd = input.ToLower();

            if (IsHelpCommand(cmd))
            {
                DisplayHelpInfo();
                return;
            }

            if (cmd == "b")
            {
                ShowBalance();
                return;
            }

            var coin = CurrencyParser<GBP>.Parse(cmd);
            if (coin.GetType() != typeof(NotSupportedPayment))
            {
                AcknowledgeCoinInserted(coin);
                return;
            }

            if (!IsValidSelection(cmd, out var selectionCode))
            {
                _console.WriteLine("Invalid selection");
                return;
            }

            var selectionResult = _vendingMachine.MakeSelection(selectionCode);
            if (selectionResult == SelectionResult.ValidSelection)
            {
                _console.WriteLine("Dispensing..");
            }
            else if (selectionResult == SelectionResult.InsufficientFunds)
            {
                _console.WriteLine("Insufficient funds");
            }
            else if (selectionResult == SelectionResult.OutOfStock)
            {
                _console.WriteLine("Out of stock");
            }
        }

        private void AcknowledgeCoinInserted(ICashPayment coin)
        {
            _vendingMachine.AddPayment(coin);
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Inserted {regionInfo.CurrencySymbol}{coin.Value}");
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

        void DisplayHelpInfo()
        {
            _console.WriteLine("Usage:");
            _console.WriteLine("  /?, /h, help => to display this help information.");
            _console.WriteLine("  q, e, quit, exit => exit the application.");
            _console.WriteLine("  b       Show the current balance");
            _console.WriteLine("  1.00, 0.50, 0.20, 0.10, 0.5 => Insert £1, 50p, 20p, 10p, 5p");
            _console.WriteLine("  a[X]    Make a selection (e.g. a0, a1, etc)");
        }

        private void ShowBalance()
        {
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Balance {regionInfo.CurrencySymbol}{_vendingMachine.Balance}");
        }
    }
}