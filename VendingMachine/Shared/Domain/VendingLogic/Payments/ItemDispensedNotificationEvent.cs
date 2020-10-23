using System;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.VendingLogic.Payments
{
    public class ItemDispensedNotificationEvent : EventArgs
    {
        public PriceListStockItem2 Item { get; }

        public ItemDispensedNotificationEvent(PriceListStockItem2 item)
        {
            Guard.Against.Null(item, nameof(item));
            Item = item;
        }
    }
}
