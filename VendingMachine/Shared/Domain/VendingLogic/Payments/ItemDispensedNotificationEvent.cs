using System;
using Ardalis.GuardClauses;
using Models.Pricing;

namespace VendingLogic.Payments
{
    public class ItemDispensedNotificationEvent : EventArgs
    {
        public PriceListStockItem Item { get; }

        public ItemDispensedNotificationEvent(PriceListStockItem item)
        {
            Guard.Against.Null(item, nameof(item));
            Item = item;
        }
    }
}
