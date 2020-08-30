using AcmeSodaConsoleApp;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Moq;
using Services;
using Xunit;

namespace AcmeSodaConsole.Tests
{
    public class CommandLineMenuTests
    {
        private readonly Mock<IVendingMachine> _mockVendingMachine = new Mock<IVendingMachine>();

        [Fact]
        public void IsExitCommand_GivenExitCommands_ReturnsTrue()
        {
            var cmd = new CommandLineMenu(_mockVendingMachine.Object);

            var inputs = new[] { "q", "e", "quit", "exit", " q " };
            foreach (var input in inputs)
            {
                Assert.True(cmd.IsExitCommand(input));
            }
        }

        [Fact]
        public void IsExitCommand_GivenNonExitCommands_ReturnsFalse()
        {
            var cmd = new CommandLineMenu(_mockVendingMachine.Object);

            var inputs = new[] { "a", "b", "" };
            foreach (var input in inputs)
            {
                Assert.False(cmd.IsExitCommand(input));
            }
        }

        [Fact]
        public void IsHelpCommand_GivenExitCommands_ReturnsTrue()
        {
            var cmd = new CommandLineMenu(_mockVendingMachine.Object);

            var inputs = new[] { "/?", "/h", "help" };
            foreach (var input in inputs)
            {
                Assert.True(cmd.IsHelpCommand(input), $"Failed: {input}");
            }
        }

        [Fact]
        public void Action_Given100_InsertsPoundCoin()
        {
            var cmd = new CommandLineMenu(_mockVendingMachine.Object);
            cmd.Action("1.00");

            _mockVendingMachine.Verify(v => v.AddPayment(GBP.OnePound), Times.Once);
        }

        [Fact]
        public void Action_GivenRubbish_NoCoinsAdded()
        {
            var cmd = new CommandLineMenu(_mockVendingMachine.Object);
            cmd.Action("asdg");

            _mockVendingMachine.Verify(v => v.AddPayment(It.IsAny<ICashPayment>()), Times.Never);
        }
    }
}
