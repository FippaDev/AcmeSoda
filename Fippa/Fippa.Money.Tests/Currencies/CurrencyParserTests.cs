using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class CurrencyParserTests
    {
        [Fact]
        public void Parse_GivenEmptyString_ReturnsInvalidCoin()
        {
            var coin = CurrencyParser<PoundSterling>.Parse(string.Empty);

            Assert.Equal(typeof(NotSupportedPayment), coin.GetType());
        }

        [Fact]
        public void Parse_NonNumericString_ReturnsFalse()
        {
            var coin = CurrencyParser<PoundSterling>.Parse("+");

            Assert.Equal(typeof(NotSupportedPayment), coin.GetType());
        }

        [Fact]
        public void Parse_Given0pt60_ReturnsFalse()
        {
            var coin = CurrencyParser<PoundSterling>.Parse("0.60");

            Assert.Equal(typeof(NotSupportedPayment), coin.GetType());
        }

        [Fact]
        public void Parse_Given0pt50_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin  = CurrencyParser<PoundSterling>.Parse("0.50");

            Assert.Equal(PoundSterling.FiftyPence, coin);
        }

        [Fact]
        public void Parse_Given0pt5_ReturnsTrueAndIdentifiedAsFiftyPence()
        {
            var coin = CurrencyParser<PoundSterling>.Parse("0.5");

            Assert.Equal(PoundSterling.FiftyPence, coin);
        }
    }
}
