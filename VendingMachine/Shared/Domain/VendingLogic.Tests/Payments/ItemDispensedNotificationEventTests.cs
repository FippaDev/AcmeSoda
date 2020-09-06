using System;
using Models.Pricing;
using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests.Payments
{ 
    public class ItemDispensedNotificationEventTests
    {
        [Fact]
        public void ItemDispensedNotificationEvent_PassNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ItemDispensedNotificationEvent(null));
        }

        [Fact]
        public void ItemDispensedNotificationEvent_GivenItem_SetsProperty()
        {
            var sku = "SKU01";
            var displayName = "PepsiMax";
            var retailPrice = 0.79m;

            var item = new PriceListStockItem(sku, displayName, retailPrice);
            var dispensedNotificationEvent = new ItemDispensedNotificationEvent(item);

            Assert.Equal(sku, dispensedNotificationEvent.Item.StockKeepingUnit);
            Assert.Equal(displayName, dispensedNotificationEvent.Item.DisplayName);
            Assert.Equal(retailPrice, dispensedNotificationEvent.Item.RetailPrice);
        }
    }
}
