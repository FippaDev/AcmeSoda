using System;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests.Payments
{
    [ExcludeFromCodeCoverage]
    public class CoinModuleTests
    {
        [Fact]
        public void Constructor_HasZeroBalance()
        {
            var module = new CoinModule();
            Assert.Equal(0.00m, module.AmountDeposited);
        }

        [Fact]
        public void Add_TenPenceCoins_UpdatesBalance()
        {
            bool moneyAddedEventHandlerUsed = false;
            var module = new CoinModule();
            module.MoneyAdded += delegate { moneyAddedEventHandlerUsed = true; };
            
            module.Add(GBP.TenPence);

            Assert.Equal(0.10m, module.AmountDeposited);
            Assert.True(moneyAddedEventHandlerUsed);
        }

        [Fact]
        public void ClearTransaction_ClearsCoinCollection()
        {
            var module = new CoinModule();
            module.Add(GBP.FivePence);
            module.Add(GBP.FiftyPence);

            Assert.Equal(0.55m, module.AmountDeposited);

            module.CancelTransaction();

            Assert.Equal(0.00m, module.AmountDeposited);
        }
    }
}
