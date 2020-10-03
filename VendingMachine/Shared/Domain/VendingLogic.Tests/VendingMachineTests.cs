using System;
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
        public void AddPayment_GivenCashPayment_CallsAddOnThePaymentModule()
        {
            var vendingMachine = new VendingMachineLogic(_mockDispenserModule.Object, _mockCoinModule.Object);

            vendingMachine.AddPayment(GBP.TenPence);

            _mockCoinModule.Verify(c => c.Add(GBP.TenPence));
        }

        [Fact]
        public void AddPayment_CoinModuleGivenCardPayment_ThrowsGuardException()
        {
            var vendingMachine = new VendingMachineLogic(_mockDispenserModule.Object, _mockCoinModule.Object);

            Assert.Throws<ArgumentException>(() =>
                vendingMachine.AddPayment(new CardPayment(5.99m)));
        }
    }
}
