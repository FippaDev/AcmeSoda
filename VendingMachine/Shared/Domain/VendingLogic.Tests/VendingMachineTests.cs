using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Moq;
using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests
{
    [ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IPaymentModule<ICashPayment>> _mockCoinModule = new Mock<IPaymentModule<ICashPayment>>();

        [Fact]
        public void CancelTransaction_ResetsBalance()
        {
            var vendingMachine = new VendingMachineLogic(_mockCoinModule.Object);

            vendingMachine.AddPayment(GBP.TenPence);
            vendingMachine.CancelTransaction();

            Assert.Equal(0.00m, vendingMachine.Balance);
        }
    }
}
