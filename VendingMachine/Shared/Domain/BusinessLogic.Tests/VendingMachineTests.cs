using System.Diagnostics.CodeAnalysis;
using BusinessLogic.Payments;
using Fippa.Money.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogic.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IPaymentModule<IPayment>> _mockCoinModule = new Mock<IPaymentModule<IPayment>>();

        [TestMethod]
        public void CancelTransaction_ResetsBalance()
        {
            var vendingMachine = new VendingMachineLogic(_mockCoinModule.Object);

            vendingMachine.AddPayment(Coin.TenPence);
            vendingMachine.CancelTransaction();

            Assert.AreEqual(0.00m, vendingMachine.Balance);
        }
    }
}
