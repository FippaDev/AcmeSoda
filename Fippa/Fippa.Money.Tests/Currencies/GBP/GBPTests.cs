using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies.GBP;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class GBPTests
    {
        [Fact]
        public void Parse_GivenEmptyString_ReturnsInvalidCoin()
        {
            var coin = GBP.Parse(string.Empty);

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_NonNumericString_ReturnsFalse()
        {
            var coin = GBP.Parse("+");

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_Given0pt60_ReturnsFalse()
        {
            var coin = GBP.Parse("0.60");

            Assert.Equal(Coin.InvalidCoin, coin);
        }

        [Fact]
        public void Parse_Given0pt50_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin  = GBP.Parse("0.50");

            Assert.Equal(Coin.FiftyPence, coin);
        }

        [Fact]
        public void Parse_Given0pt5_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin = GBP.Parse("0.5");

            Assert.Equal(Coin.FiftyPence, coin);
        }
    }
}
