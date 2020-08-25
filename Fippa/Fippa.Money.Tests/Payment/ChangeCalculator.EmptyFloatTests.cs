using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies.Sterling;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
{
    [ExcludeFromCodeCoverage]
    public partial class ChangeCalculatorTests
    {
        [Fact]
        public void Change_WhenEmptyFloat_ReturnsEmptyResult()
        {
            var cashFloat = new CashFloat<Sterling>();
            var change = cashFloat.CalculateChangeToReturnToCustomer(0.99m);

            Assert.Empty(change);
        }
    }
}
