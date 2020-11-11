using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class GbpCurrencyTests
    {
        [Fact]
        public void OnePenny_HasRightMonetaryValue()
        {
            Assert.Equal(0.01m, Money.Currencies.GBP.OnePenny);
        }

        [Fact]
        public void TwoPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.02m, Money.Currencies.GBP.TwoPence);
        }

        [Fact]
        public void FivePence_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, Money.Currencies.GBP.FivePence);
        }

        [Fact]
        public void TenPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, Money.Currencies.GBP.TenPence);
        }

        [Fact]
        public void TwentyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.20m, Money.Currencies.GBP.TwentyPence);
        }

        [Fact]
        public void FiftyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, Money.Currencies.GBP.FiftyPence.Value);
        }

        [Fact]
        public void OnePound_HasRightMonetaryValue()
        {
            Assert.Equal(1.00m, Money.Currencies.GBP.OnePound);
        }

        [Fact]
        public void TwoPound_HasRightMonetaryValue()
        {
            Assert.Equal(2.00m, Money.Currencies.GBP.TwoPound);
        }
    }
}
