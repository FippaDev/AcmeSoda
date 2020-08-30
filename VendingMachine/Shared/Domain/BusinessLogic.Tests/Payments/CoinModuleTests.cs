using System.Diagnostics.CodeAnalysis;
using BusinessLogic.Payments;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests.Payments
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CoinModuleTests
    {
        [TestMethod]
        public void Constructor_HasZeroBalance()
        {
            var module = new CoinModule();
            Assert.AreEqual(0.00m, module.AmountDeposited);
        }

        [TestMethod]
        public void Add_TenPenceCoins_UpdatesBalance()
        {
            bool moneyAddedEventHandlerUsed = false;
            var module = new CoinModule();
            module.MoneyAdded += delegate { moneyAddedEventHandlerUsed = true; };
            
            module.Add(GBP.TenPence);

            Assert.AreEqual(0.10m, module.AmountDeposited);
            Assert.IsTrue(moneyAddedEventHandlerUsed);
        }
    }
}
