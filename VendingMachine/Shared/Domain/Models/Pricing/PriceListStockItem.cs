using Ardalis.GuardClauses;
using Models.Exceptions;
using Models.Stock;

namespace Models.Pricing
{
    public class PriceListStockItem : BaseStockItem
    {
        public string DisplayName { get; }
        public decimal RetailPrice { get; }

        public PriceListStockItem(string stockKeepingUnit, string displayName, decimal retailPrice)
            : base(stockKeepingUnit)
        {
            Guard.Against.NullOrEmpty(displayName, nameof(displayName));
            if (retailPrice < 0.0m)
            {
                throw new InvalidStockItemPriceException("Cannot have items with a negative retail price.");
            }
            
            DisplayName = displayName;
            RetailPrice = retailPrice;
        }
    }
}
