using System.Globalization;
using Ardalis.GuardClauses;
using Fippa.IO.Console;
using Fippa.Money.Payments;
using Services;
using UserInterface;
using VendingLogic.Payments;

namespace AcmeSodaConsoleApp
{
    public class CommandLineMenu : IUserInput
    {
        private readonly IConsole _console;
        private readonly IVendingMachine _vendingMachine;


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

        private void AcknowledgeCoinInserted(ICashPayment coin)
        {
            _vendingMachine.AddPayment(coin);
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Inserted {regionInfo.CurrencySymbol}{coin.Value}");
        }

        private void ShowBalance()
        {
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Balance {regionInfo.CurrencySymbol}{_vendingMachine.Balance}");
        }

        public string WaitForUserInput()
        {
            return _console.ReadLine();
        }
    }
}