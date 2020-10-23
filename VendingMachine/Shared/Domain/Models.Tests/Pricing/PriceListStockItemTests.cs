using System;
using System.Diagnostics.CodeAnalysis;
using VendingMachine.Shared.Domain.Models.Exceptions;
using VendingMachine.Shared.Domain.Models.Pricing;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Pricing
{
    [ExcludeFromCodeCoverage]
    public class PriceListStockItemTests
    {
        [Fact]
        public void Constructor_EmptyName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var item = new PriceListStockItem2(string.Empty, string.Empty, 0.00m);
            });
        }

        [Fact]
        public void Constructor_WithEmptyName_ThrowsException()
        {
            Assert.Throws<InvalidStockItemPriceException>(() =>
            {
                var item = new PriceListStockItem2("PC", "PepsiMax 330ml", 0.00m);
            });
        }
    }
}
