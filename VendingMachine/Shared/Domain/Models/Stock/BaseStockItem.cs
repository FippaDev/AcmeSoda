using Ardalis.GuardClauses;

namespace Models.Stock
{
    public abstract class BaseStockItem
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string StockKeepingUnit { get; }

        protected BaseStockItem(string stockKeepingUnit)
        {
            Guard.Against.NullOrEmpty(stockKeepingUnit, nameof(stockKeepingUnit));

            StockKeepingUnit = stockKeepingUnit;
        }
    }
}
