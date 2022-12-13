using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Fippa.IO.Console;
using Fippa.Money.Currencies;
using Unity;
using UserInterface;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Domain.Models.VendingMachine;

namespace AcmeSodaConsoleApp
{
    internal class ConsoleKeypad : IUserInput
    {
        private readonly IConsole _console;
        private readonly IUnityContainer _unityContainer;
        private IVendingMachine? _vendingMachine;

        private static readonly IList<string> ExitCommands = new List<string> { "q", "quit", "e", "exit" };
        private static readonly IList<string> HelpCommands = new List<string> { "/?", "/h", "help" };

        public ConsoleKeypad(IConsole console, IUnityContainer unityContainer)
        {
            _console = console;
            _unityContainer = unityContainer;
        }

        public void SetVendingMachineType(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public void Run()
        {
            Guard.Against.Null(_vendingMachine, "The vending machine type must be specified before running");

            var input = _console.ReadLine();
            while (input != null && !IsExitCommand(input))
            {
                ProcessInput(input);
                input = Console.ReadLine();
            }
        }

        private void ProcessInput(in string input)
        {
            Guard.Against.Null(_vendingMachine, "The vending machine type must be specified before running");

            var cmd = input.ToLower().Trim();

            if (IsHelpCommand(cmd))
            {
                DisplayHelpInfo();
                return;
            }

            if (cmd == "s")
            {
                var reportGenerator = _unityContainer.Resolve<IStockReporting>();
                _vendingMachine.ShowStockLevels(reportGenerator);
                return;
            }

            var coin = CurrencyParser<PoundSterling>.Parse(cmd);
            if (coin.GetType() != typeof(NotSupportedPayment))
            {
                _vendingMachine.AddPayment(coin);
                return;
            }

            // Assume cmd is a selection command
            var selectionResult = _vendingMachine.MakeSelection(cmd);

            if (selectionResult == SelectionResult.InvalidSelection)
            {
                _console.WriteLine("Invalid selection");
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

        private void DisplayHelpInfo()
        {
            _console.WriteLine("Usage:");
            _console.WriteLine("  /?, /h, help => to display this help information.");
            _console.WriteLine("  q, e, quit, exit => exit the application.");
            _console.WriteLine("  v => view stock levels");
            _console.WriteLine("  1.00, 0.50, 0.20, 0.10, 0.5 => Insert £1, 50p, 20p, 10p, 5p");
            _console.WriteLine("  a[X]    Make a selection (e.g. a0, a1, etc)");
        }

        private static bool IsExitCommand(in string input)
        {
            return ExitCommands.Contains(input.Trim().ToLower());
        }

        private static bool IsHelpCommand(in string input)
        {
            return HelpCommands.Contains(input.Trim().ToLower());
        }
    }
}
