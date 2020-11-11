using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class UsdCurrencyTests
    {
        [Fact]
        public void OneCent_HasRightMonetaryValue()
        {
            Assert.Equal(0.01m, Money.Currencies.USD.Cent);
        }

        [Fact]
        public void Nickel_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, Money.Currencies.USD.Nickel);
        }

        [Fact]
        public void Dime_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, Money.Currencies.USD.Dime);
        }

        [Fact]
        public void Quarter_HasRightMonetaryValue()
        {
            Assert.Equal(0.25m, Money.Currencies.USD.Quarter);
        }

        [Fact]
        public void HalfDollar_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, Money.Currencies.USD.HalfDollar);
        }
    }
}
