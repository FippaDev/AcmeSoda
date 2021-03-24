using System.Collections.Generic;
using Fippa.Money.Change;
using Fippa.Money.Currencies;
using FluentAssertions;
using Xunit;

namespace Fippa.Money.Tests.Change
{
    public class ChangeCalculatorTests
    {
        [Fact]
        public void GetChange_WhenPurchaseGreaterThanCoinsIn_ReturnsInsufficientFundsError()
        {
            var cashFloat = CashFloatSetup.SmallFloat();
            var calculator = new ChangeCalculator<GBP>(cashFloat);

            var coinsIn = new List<GBP>(new [] {GBP.OnePound });
            decimal purchase = 1.25m;

            var result = calculator.GetChange(coinsIn, purchase);

            result.Successful.Should().BeFalse();
        }
    }
}
