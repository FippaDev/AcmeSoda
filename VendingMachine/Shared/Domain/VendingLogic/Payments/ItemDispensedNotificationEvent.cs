using System;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.DomainServices.Payments
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
