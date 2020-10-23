using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Pricing
{
    public class PriceList2
    {
        // Key = SKU
        // Value = PriceListStockItem (with DisplayName and RRP)
        private readonly Dictionary<string, PriceListStockItem2> _items;

        public PriceListStockItem2 GetItem(string sku)
        {
            return _items[sku];
        }

        public PriceList2(IEnumerable<PriceListStockItem2> items)
        {
            var priceListStockItems = items as PriceListStockItem2[] ?? items.ToArray();

            Guard.Against.Null(priceListStockItems, nameof(items));

            _items = new Dictionary<string, PriceListStockItem2>();
            foreach (PriceListStockItem2 i in priceListStockItems)
            {
                _items.Add(
                    i.StockKeepingUnit, 
                    new PriceListStockItem2(i.StockKeepingUnit, i.DisplayName, i.RetailPrice));
            }
        }
    }
}
