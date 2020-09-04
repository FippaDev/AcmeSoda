using System.Diagnostics.CodeAnalysis;
using Models.Stock;
using Xunit;

namespace Models.Tests.Stock
{
    [ExcludeFromCodeCoverage]
    public class BaseStockItemTests
    {
        [Fact]
        public void Constructor_GetterSKU_ReturnsSKU()
        {
            const string sku = "sku99";
            var crisps = new Crisps(sku);

            Assert.Equal(sku, crisps.StockKeepingUnit);
        }
    }
}
