using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
{
    [ExcludeFromCodeCoverage]
    public class ChangeCalculatorTests
    {
        private readonly ushort MaxCoinsPerDenomination = 100;

        [Fact]
        public void AddCoinsToCashFloat_GivenTenPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoinsToCashFloat(GBP.TenPence, 12);

            Assert.Equal(1.20m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoinsToCashFloat_GivenTenAndTwentyPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            cashFloat.AddCoinsToCashFloat(GBP.TenPence, 1);
            cashFloat.AddCoinsToCashFloat(GBP.TwentyPence, 2);

            Assert.Equal(0.5m, cashFloat.Balance);
        }
    }
}
