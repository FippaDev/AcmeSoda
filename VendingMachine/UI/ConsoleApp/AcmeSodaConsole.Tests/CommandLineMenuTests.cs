using System;
using System.Globalization;
using System.Linq.Expressions;
using AcmeSodaConsoleApp;
using Fippa.IO.Console;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Moq;
using Services;
using Xunit;

namespace AcmeSodaConsole.Tests
{
    public class CommandLineMenuTests
    {
        private readonly Mock<IConsole> _mockConsole = new Mock<IConsole>();
        private readonly Mock<IVendingMachine> _mockVendingMachine = new Mock<IVendingMachine>();

        [Fact]
        public void IsExitCommand_GivenExitCommands_ReturnsTrue()
        {
            var cmd = new CommandLineMenu(_mockConsole.Object, _mockVendingMachine.Object);

            var inputs = new[] { "q", "e", "quit", "exit", " q " };
            foreach (var input in inputs)
            {
                Assert.True(cmd.IsExitCommand(input));
            }
        }

        [Fact]
        public void IsExitCommand_GivenNonExitCommands_ReturnsFalse()
        {
            var cmd = new CommandLineMenu(_mockConsole.Object, _mockVendingMachine.Object);

            var inputs = new[] { "a", "b", "" };
            foreach (var input in inputs)
            {
                Assert.False(cmd.IsExitCommand(input));
            }
        }

        [Fact]
        public void IsHelpCommand_GivenExitCommands_ReturnsTrue()
        {
            var cmd = new CommandLineMenu(_mockConsole.Object, _mockVendingMachine.Object);

            var inputs = new[] { "/?", "/h", "help" };
            foreach (var input in inputs)
            {
                Assert.True(cmd.IsHelpCommand(input), $"Failed: {input}");
            }
        }

        [Fact]
        public void Action_Given100_InsertsPoundCoin()
        {
            var cmd = new CommandLineMenu(_mockConsole.Object, _mockVendingMachine.Object);
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            var expectedOutput = $"Inserted {regionInfo.CurrencySymbol}1.00";

            cmd.Action("1.00");

            _mockVendingMachine.Verify(v => v.AddPayment(GBP.OnePound), Times.Once);
            _mockConsole.Verify(c => c.WriteLine(expectedOutput));
        }

        [Fact]
        public void Action_GivenRubbish_NoCoinsAdded()
        {
            var cmd = new CommandLineMenu(_mockConsole.Object, _mockVendingMachine.Object);
            cmd.Action("&");

            _mockVendingMachine.Verify(v => v.AddPayment(It.IsAny<ICashPayment>()), Times.Never);
        }

        [Fact]
        public void Action_GivenInputB_ShowsBalance()
        {
            var console = new Mock<IConsole>();
            var cmd = new CommandLineMenu(console.Object, _mockVendingMachine.Object);
            _mockVendingMachine.Setup(v => v.Balance).Returns(1.35m);

            cmd.Action("b");

            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            console.Verify(c => c.WriteLine($"Balance {regionInfo.CurrencySymbol}1.35"));
        }

        [Theory]
        [InlineData(@"/?")]
        [InlineData(@"/h")]
        [InlineData(@"help")]
        public void Action_GivenRequestForHelp_ShowsHelp(string argument)
        {
            var console = new Mock<IConsole>();
            var cmd = new CommandLineMenu(console.Object, _mockVendingMachine.Object);
            _mockVendingMachine.Setup(v => v.Balance).Returns(1.35m);

            cmd.Action(argument);

            console.Verify(c => c.WriteLine(It.Is<string>(s => s.StartsWith("Usage:"))));
        }
    }
}
