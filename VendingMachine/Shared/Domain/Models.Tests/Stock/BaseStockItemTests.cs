using System.Diagnostics.CodeAnalysis;
using VendingMachine.Shared.Domain.Models.Stock;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Stock
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
