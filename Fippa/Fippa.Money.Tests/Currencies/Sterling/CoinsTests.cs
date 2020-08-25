using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies.Sterling;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class CoinsTests
    {
        [Fact]
        public void FivePence_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, Coin.FivePence);
        }

        [Fact]
        public void TenPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, Coin.TenPence);
        }

        [Fact]
        public void TwentyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.20m, Coin.TwentyPence);
        }

        [Fact]
        public void FiftyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, Coin.FiftyPence.Value);
        }

        [Fact]
        public void OnePound_HasRightMonetaryValue()
        {
            Assert.Equal(1.00m, Coin.OnePound);
        }

        [Fact]
        public void TwoPound_HasRightMonetaryValue()
        {
            Assert.Equal(2.00m, Coin.TwoPound);
        }
    }
}
