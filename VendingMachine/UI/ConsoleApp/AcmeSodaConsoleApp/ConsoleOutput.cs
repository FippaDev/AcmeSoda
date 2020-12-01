using System.Globalization;
using System.Threading;
using Fippa.IO.Console;
using VendingMachine.Shared.Services;

namespace AcmeSodaConsoleApp
{
    public class ConsoleOutput : IUserOutput
    {
        private readonly IConsole _console;

        public ConsoleOutput(IConsole console)
        {
            _console = console;
        }

        public void ShowBalance(decimal balance)
        {
            var regionInfo = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
            _console.WriteLine($"Balance {regionInfo.CurrencySymbol}{balance}");
        }

        public void ShowWelcomeMessage(string manufacturer)
        {
            _console.WriteLine($"ACME Vending Machine ({manufacturer})");
            _console.WriteLine("----------------------------");
        }

        public void Message(string message)
        {
            _console.WriteLine(message);
        }
    }
}
