using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Exceptions;
using Models.Pricing;

namespace Models.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class PriceListStockItemTests
    {
        [TestMethod, ExpectedException(typeof(InvalidStockItemPriceException))]
        public void Constructor_GivenInvalidPrice_ThrowsException()
        {
            var priceListStockItem = new PriceListStockItem("SKU00", "Something", -0.99m);
        }

        [TestMethod]
        public void Constructor_GivenGoodValues_SetsProperties()
        {
            var listItem = new PriceListStockItem("SKU99", "Label", 0.99m);
            Assert.AreEqual("SKU99", listItem.StockKeepingUnit);
            Assert.AreEqual("Label", listItem.DisplayName);
            Assert.AreEqual(0.99m, listItem.RetailPrice);
        }
    }
}
