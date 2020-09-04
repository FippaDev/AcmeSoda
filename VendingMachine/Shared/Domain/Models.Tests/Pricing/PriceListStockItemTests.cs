using System;
using System.Diagnostics.CodeAnalysis;
using Models.Exceptions;
using Models.Pricing;
using Xunit;

namespace Models.Tests.Pricing
{
    [ExcludeFromCodeCoverage]
    public class PriceListStockItemTests
    {
        [Fact]
        public void Constructor_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var item = new PriceListStockItem(string.Empty, string.Empty, 0.00m);
            });
        }

        [Fact]
        public void Constructor_WithEmptyName_ThrowsException()
        {
            Assert.Throws<InvalidStockItemPriceException>(() =>
            {
                var item = new PriceListStockItem("PC", "PepsiMax 330ml", 0.00m);
            });
        }
    }
}
