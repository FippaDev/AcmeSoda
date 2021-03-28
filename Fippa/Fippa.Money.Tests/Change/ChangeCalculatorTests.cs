using System;
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
        public void Constructor_IfCashFloatIsNull_ThrowArguementNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new ChangeCalculator<GBP>(null);
            });
        }

        [Fact]
        public void GetChange_IfCoinsInIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cashFloat = CashFloatSetup.SmallFloat();
                var calculator = new ChangeCalculator<GBP>(cashFloat);

                decimal purchase = 1.25m;

                var result = calculator.GetChange(null, purchase);

                result.Successful.Should().BeFalse();
            });
        }

        [Fact]
        public void GetChange_WhenNoCoinsInNoChangeGive()
        {
            var cashFloat = CashFloatSetup.SmallFloat();
            var calculator = new ChangeCalculator<GBP>(cashFloat);

            var coinsIn = new List<GBP>();
            decimal purchase = 1.25m;

            var result = calculator.GetChange(coinsIn, purchase);

            result.Successful.Should().BeFalse();
        }

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
