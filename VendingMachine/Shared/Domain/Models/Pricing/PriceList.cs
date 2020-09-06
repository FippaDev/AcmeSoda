using System.Collections.Generic;

namespace Models.Pricing
{
    // Key = SKU
    // Value = PriceListStockItem (with DisplayName and RRP)
    public class PriceList
    {
        private Dictionary<string, PriceListStockItem> Items { get; } = new Dictionary<string, PriceListStockItem>();

        public PriceListStockItem GetItem(string sku)
        {
            return Items[sku];
        }
    }
}
