using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Fippa.Money.Tests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class UnitedStatesDollarCurrencyTests
    {
        [Fact]
        public void OneCent_HasRightMonetaryValue()
        {
            Assert.Equal(0.01m, Money.Currencies.UnitedStatesDollar.Cent);
        }

        [Fact]
        public void Nickel_HasRightMonetaryValue()
        {
            Assert.Equal(0.05m, Money.Currencies.UnitedStatesDollar.Nickel);
        }

        [Fact]
        public void Dime_HasRightMonetaryValue()
        {
            Assert.Equal(0.10m, Money.Currencies.UnitedStatesDollar.Dime);
        }

        [Fact]
        public void Quarter_HasRightMonetaryValue()
        {
            Assert.Equal(0.25m, Money.Currencies.UnitedStatesDollar.Quarter);
        }

        [Fact]
        public void HalfDollar_HasRightMonetaryValue()
        {
            Assert.Equal(0.50m, Money.Currencies.UnitedStatesDollar.HalfDollar);
        }
    }
}
