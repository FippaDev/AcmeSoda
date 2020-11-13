﻿using System;
using System.Collections.Generic;
using Fippa.IO.Console;
using Fippa.Money.Currencies;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace AcmeSodaConsoleApp
{
    internal class ConsoleKeypad : IUserInput
    {
        private readonly IConsole _console;
        private IVendingMachine _vendingMachine;

        private static readonly IList<string> ExitCommands = new List<string> { "q", "quit", "e", "exit" };
        private static readonly IList<string> HelpCommands = new List<string> { "/?", "/h", "help" };

        public ConsoleKeypad(IConsole console)
        {
            _console = console;
        }

        public void Run(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;

            var input = _console.ReadLine();
            while (!IsExitCommand(input))
            {
                ProcessInput(input);
                input = Console.ReadLine();
            }
        }

        private void ProcessInput(in string input)
        {
            var cmd = input.ToLower();

            if (IsHelpCommand(cmd))
            {
                DisplayHelpInfo();
                return;
            }

            var coin = CurrencyParser<GBP>.Parse(cmd);
            if (coin.GetType() != typeof(NotSupportedPayment))
            {
                _vendingMachine.AddCommand(new PaymentCommand(coin.Value));
                return;
            }

            // Assume cmd is a selection command
            string selectionCode = cmd;
            Tuple<ProductCommand, SelectionResult> result = _vendingMachine.IdentifyProductBySelectionCode(selectionCode);
            ProductCommand product = result.Item1;
            SelectionResult selectionResult = result.Item2;

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
            else if (selectionResult == SelectionResult.InvalidSelection)
            {
                _console.WriteLine("Invalid selection");
            }
        }

        private void DisplayHelpInfo()
        {
            _console.WriteLine("Usage:");
            _console.WriteLine("  /?, /h, help => to display this help information.");
            _console.WriteLine("  q, e, quit, exit => exit the application.");
            _console.WriteLine("  1.00, 0.50, 0.20, 0.10, 0.5 => Insert £1, 50p, 20p, 10p, 5p");
            _console.WriteLine("  a[X]    Make a selection (e.g. a0, a1, etc)");
        }

        private bool IsExitCommand(in string input)
        {
            return ExitCommands.Contains(input.Trim().ToLower());
        }

        private bool IsHelpCommand(in string input)
        {
            return HelpCommands.Contains(input.Trim().ToLower());
        }
    }
}
