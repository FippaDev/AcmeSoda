﻿using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payments
{
    [ExcludeFromCodeCoverage]
    public class ChangeCalculatorTests
    {
        private readonly ushort MaxCoinsPerDenomination = 100;

        [Fact]
        public void CalculateChangeToReturnToCustomer_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var change = cashFloat.CalculateChangeToReturnToCustomer(0.99m);

            Assert.Empty(change);
        }

        [Fact]
        public void AddCoinsToCashFloat_GivenTenPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(GBP.TenPence, 12);

            Assert.Equal(1.20m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoinsToCashFloat_GivenTenAndTwentyPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoins(GBP.TenPence, 1);
            cashFloat.AddCoins(GBP.TwentyPence, 2);

            Assert.Equal(0.5m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoinsToCashFloat_WhenAddingMoreCoinsThanSlots_ReturnsExcessCoins()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var excessCoins = cashFloat.AddCoins(GBP.TenPence, (ushort)(MaxCoinsPerDenomination + 2));

            Assert.Equal(2, excessCoins);
            Assert.Equal(10.00m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoinsToCashFloat_GivenUSDCoins_ReturnsNotSupported()
        {
            ushort quantity = 2;
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var excessCoins = cashFloat.AddCoins(USD.Nickel, quantity);

            Assert.Equal(quantity, excessCoins);
        }

        [Fact]
        public void Change_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var change = cashFloat.CalculateChangeToReturnToCustomer(0.99m);

            Assert.Empty(change);
        }
    }
}
