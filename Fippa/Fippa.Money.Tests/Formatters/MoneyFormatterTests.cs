using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Formatters;
using Xunit;

namespace Fippa.Money.Tests.Formatters
{
    [ExcludeFromCodeCoverage]
    public class MoneyFormatterTests
    {
        [Fact]
        public void DisplayAsCurrency_WhenZero_DisplaysZeroPointZeroPounds()
        {
            decimal d = 0.00m;

            Assert.Equal("£0.00", d.DisplayAsCurrency());
        }

        [Fact]
        public void DisplayAsCurrency_WhenNonZero_DisplaysThreeNinetyEight()
        {
            decimal d = 3.98m;

            Assert.Equal("£3.98", d.DisplayAsCurrency());
        }
    }
}
