using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;
using Xunit;

namespace Fippa.Money.Tests.Payment
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

        [Fact]
        public void Parse_GivenEmptyString_ReturnsInvalidCoin()
        {
            var coin = Coin.Parse(string.Empty);

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_NonNumericString_ReturnsFalse()
        {
            var coin = Coin.Parse("+");

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_Given0pt60_ReturnsFalse()
        {
            var coin = Coin.Parse("0.60");

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_Given0pt50_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin  = Coin.Parse("0.50");

            Assert.Equal(Coin.FiftyPence, coin);
        }

        [Fact]
        public void Parse_Given0pt5_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin = Coin.Parse("0.5");

            Assert.Equal(Coin.FiftyPence, coin);
        }
    }
}
