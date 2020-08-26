using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies.Sterling;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
{
    [ExcludeFromCodeCoverage]
    public partial class ChangeCalculatorTests
    {
        private readonly ushort MaxCoinsPerDenomination = 10;

        [Fact]
        public void AddCoinsToCashFloat_GivenTenPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<Sterling>(MaxCoinsPerDenomination);
            cashFloat.AddCoinsToCashFloat(Coin.TenPence, 12);

            Assert.Equal(1.20m, cashFloat.Balance);
        }

        [Fact]
        public void AddCoinsToCashFloat_GivenTenAndTwentyPencePieces_BalanceReflectsTheCoinsAdded()
        {
            var cashFloat = new CashFloat<Sterling>(MaxCoinsPerDenomination);
            cashFloat.AddCoinsToCashFloat(Coin.TenPence, 1);
            cashFloat.AddCoinsToCashFloat(Coin.TwentyPence, 2);

            Assert.Equal(0.5m, cashFloat.Balance);
        }
    }
}
