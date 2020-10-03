using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using FluentAssertions;
using Models;
using Moq;
using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests
{
    [ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IPaymentModule<ICashPayment>> _mockCoinModule = new Mock<IPaymentModule<ICashPayment>>();
        private readonly Mock<IDispenserModule> _mockDispenserModule = new Mock<IDispenserModule>();

        [Fact]
        public void CancelTransaction_ResetsBalance()
        {
            var vendingMachine = new VendingMachineLogic(_mockDispenserModule.Object, _mockCoinModule.Object);

            vendingMachine.AddPayment(GBP.TenPence);
            vendingMachine.CancelTransaction();

            Assert.Equal(0.00m, vendingMachine.Balance);
        }

        [Fact]
        public void BalanceChanged_RaisesBalanceChangedEvent()
        {
            var receivedEvents = new List<decimal>();
            var vendingMachine = new VendingMachineLogic(_mockDispenserModule.Object, _mockCoinModule.Object);

            vendingMachine.BalanceChanged +=
                delegate(object sender, BalanceChangedEvent changedEvent)
                {
                    receivedEvents.Add(changedEvent.Balance);
                };

            vendingMachine.AddPayment(GBP.TwentyPence);
            vendingMachine.AddPayment(GBP.TwentyPence);
            vendingMachine.AddPayment(GBP.TenPence);

            receivedEvents.Count.Should().Be((int)0.5m);
        }
    }
}
