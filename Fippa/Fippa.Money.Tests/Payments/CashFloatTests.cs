using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payments
{
    [ExcludeFromCodeCoverage]
    public class CashFloatTests
    {
        private readonly ushort MaxCoinsPerDenomination = 100;

        [Fact]
        public void GetChange_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var change = cashFloat.GetChange(0.99m);

            Assert.Empty(change);
        }

        [Fact]
        public void AddCoins_GivenTenPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(coin: GBP.TenPence, quantity: 12);

            Assert.Equal(1.20m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoins_GivenFivePencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(
                new ICashPayment[]
                {
                    GBP.FivePence,
                    GBP.FivePence
                });

            Assert.Equal(0.10m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoins_GivenMixedCurrencyCoins_ThrowsAnException()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);

            Assert.Throws<ArgumentException>(() =>
            {
                cashFloat.AddCoins(
                    new ICashPayment[]
                    {
                        GBP.FivePence,
                        USD.Nickel
                    });
            });
        }

        [Fact]
        public void AddCoins_GivenTenAndTwentyPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(GBP.TenPence, 1);
            cashFloat.AddCoins(GBP.TwentyPence, 2);

            Assert.Equal(0.5m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoins_WhenAddingMoreCoinsThanSlots_ReturnsExcessCoins()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var excessCoins = cashFloat.AddCoins(GBP.TenPence, (ushort)(MaxCoinsPerDenomination + 2));

            Assert.Equal(2, excessCoins);
            Assert.Equal(10.00m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoins_GivenUSDCoins_ReturnsNotSupported()
        {
            ushort quantity = 2;
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var excessCoins = cashFloat.AddCoins(USD.Nickel, quantity);

            Assert.Equal(quantity, excessCoins);
        }

        private CashFloat<GBPCoins> CreateSampleCashFloat()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(GBP.FivePence, 2);
            cashFloat.AddCoins(GBP.TenPence, 2);
            cashFloat.AddCoins(GBP.TwentyPence, 2);
            cashFloat.AddCoins(GBP.FiftyPence, 2);
            cashFloat.AddCoins(GBP.OnePound, 2);
            return cashFloat;
        }

        [Fact]
        public void GetChange_WhereCoinsAvailable_ReturnsChangeAndAdjustsFloat()
        {
            var cashFloat = CreateSampleCashFloat();

            var transactionTotal = 1.65m;
            var customerPayment =
                new ICashPayment[]
                {
                    GBP.OnePound,
                    GBP.OnePound
                };

            var customerPaymentTotal = customerPayment.Sum(c => c.Value);
            var changeRequired = customerPaymentTotal - transactionTotal;

            var floatBalanceBefore = cashFloat.Balance;

            // 1. Put the entered coins in the cash float (they may be returned if an overpayment)
            cashFloat.AddCoins(customerPayment);

            // 2. Dispense the change
            var returnedCoins = cashFloat.GetChange(changeRequired);
            
            var returnedSum = returnedCoins.Sum(c => c.Key.Value * c.Value);

            var floatBalanceAfter = cashFloat.Balance;

            Assert.Equal(0.35m, returnedSum);
            Assert.Equal(floatBalanceAfter, floatBalanceBefore + transactionTotal);
        }
    }
}
