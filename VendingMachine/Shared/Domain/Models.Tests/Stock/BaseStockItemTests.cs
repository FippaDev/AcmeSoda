using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Stock;

namespace Models.Tests.Stock
{
    [TestClass, ExcludeFromCodeCoverage]
    public class BaseStockItemTests
    {
        [TestMethod]
        public void Constructor_GetterSKU_ReturnsSKU()
        {
            const string sku = "sku99";
            var crisps = new Crisps(sku);

            Assert.AreEqual<string>(sku, crisps.StockKeepingUnit);
        }
    }
}
