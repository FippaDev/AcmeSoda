using System.Collections.Generic;

namespace Models.Pricing
{
    public class PriceList
    {
        private Dictionary<ushort, PriceListStockItem> Items { get; } = new Dictionary<ushort, PriceListStockItem>();

        public PriceListStockItem this[ushort selectionCode] => Items[selectionCode];

        public bool Has(ushort selectionCode)
        {
            return Items.ContainsKey(selectionCode);
        }
    }
}
