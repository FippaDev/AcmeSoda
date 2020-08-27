using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
{
    [ExcludeFromCodeCoverage]
    public class ChangeCalculatorFloatTests
    {
        private readonly ushort MaxCoinsPerDenomination = 10;

        [Fact]
        public void Change_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<GBPCoins>(MaxCoinsPerDenomination);
            var change = cashFloat.CalculateChangeToReturnToCustomer(0.99m);

            Assert.Empty(change);
        }
    }
}
