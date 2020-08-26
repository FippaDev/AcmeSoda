using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies.USD;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
{
    [ExcludeFromCodeCoverage]
    public partial class ChangeCalculatorFloatTests
    {
        private readonly ushort MaxCoinsPerDenomination = 10;

        [Fact]
        public void Change_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<USD>(MaxCoinsPerDenomination);
            var change = cashFloat.CalculateChangeToReturnToCustomer(0.99m);

            Assert.Empty(change);
        }
    }
}
