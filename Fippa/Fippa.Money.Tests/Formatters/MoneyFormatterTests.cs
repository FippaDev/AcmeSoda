using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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

            var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            Assert.Equal($"{ri.CurrencySymbol}0.00", d.DisplayAsCurrency());
        }

        [Fact]
        public void DisplayAsCurrency_WhenNonZero_DisplaysThreeNinetyEight()
        {
            decimal d = 3.98m;

            var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
            Assert.Equal($"{ri.CurrencySymbol}3.98", d.DisplayAsCurrency());
        }
    }
}
