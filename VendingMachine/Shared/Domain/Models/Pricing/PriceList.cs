using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Pricing
{
    public class PriceList
    {
        // Key = SKU
        // Value = PriceListStockItem (with DisplayName and RRP)
        private readonly Dictionary<string, PriceListStockItem> _items;

        public PriceListStockItem GetProductDetails(string sku)
        {
            return _items[sku];
        }

        public PriceList(IEnumerable<PriceListStockItem> items)
        {
            var priceListStockItems = items as PriceListStockItem[] ?? items.ToArray();

            Guard.Against.Null(priceListStockItems, nameof(items));

            _items = new Dictionary<string, PriceListStockItem>();
            foreach (PriceListStockItem i in priceListStockItems)
            {
                _items.Add(
                    i.StockKeepingUnit, 
                    new PriceListStockItem(i.StockKeepingUnit, i.DisplayName, i.RetailPrice));
            }
        }

        public decimal LookupByStockKeepingUnit(string sku)
        {
            return _items
                .Single(i => i.Key.Equals(sku, StringComparison.OrdinalIgnoreCase))
                .Value.RetailPrice;
        }
    }
}
