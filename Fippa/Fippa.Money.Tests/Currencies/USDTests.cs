using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class USDTests
    {
        [Fact]
        public void OneCent_HasRightMonetaryValue()
        {
            Assert.Equal(0.01m, USD.Cent);
        }

        [Fact]
        public void Nickel_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, USD.Nickel);
        }

        [Fact]
        public void Dime_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, USD.Dime);
        }

        [Fact]
        public void Quarter_HasRightMonetaryValue()
        {
            Assert.Equal(0.25m, USD.Quarter);
        }

        [Fact]
        public void HalfDollar_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, USD.HalfDollar);
        }
    }
}
