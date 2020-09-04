﻿using System.Diagnostics.CodeAnalysis;
using Models.Exceptions;
using Models.Pricing;
using Xunit;

namespace Models.Tests
{
    [ExcludeFromCodeCoverage]
    public class PriceListStockItemTests
    {
        [Fact]
        public void Constructor_GivenInvalidPrice_ThrowsException()
        {
            Assert.Throws<InvalidStockItemPriceException>(() =>
            {
                var priceListStockItem = new PriceListStockItem("SKU00", "Something", -0.99m);
            });
        }

        [Fact]
        public void Constructor_GivenGoodValues_SetsProperties()
        {
            var listItem = new PriceListStockItem("SKU99", "Label", 0.99m);
            Assert.Equal("SKU99", listItem.StockKeepingUnit);
            Assert.Equal("Label", listItem.DisplayName);
            Assert.Equal(0.99m, listItem.RetailPrice);
        }
    }
}
