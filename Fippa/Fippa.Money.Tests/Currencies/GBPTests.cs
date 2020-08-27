using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class GBPTests
    {
        [Fact]
        public void OnePenny_HasRightMonetaryValue()
        {
            Assert.Equal(0.01m, GBP.OnePenny);
        }

        [Fact]
        public void TwoPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.02m, GBP.TwoPence);
        }

        [Fact]
        public void FivePence_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, GBP.FivePence);
        }

        [Fact]
        public void TenPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, GBP.TenPence);
        }

        [Fact]
        public void TwentyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.20m, GBP.TwentyPence);
        }

        [Fact]
        public void FiftyPence_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, GBP.FiftyPence.Value);
        }

        [Fact]
        public void OnePound_HasRightMonetaryValue()
        {
            Assert.Equal(1.00m, GBP.OnePound);
        }

        [Fact]
        public void TwoPound_HasRightMonetaryValue()
        {
            Assert.Equal(2.00m, GBP.TwoPound);
        }
    }
}
