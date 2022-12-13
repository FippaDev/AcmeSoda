using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Pricing;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainServices.Tests.Payments;

public class ItemDispensedNotificationEventTests
{
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