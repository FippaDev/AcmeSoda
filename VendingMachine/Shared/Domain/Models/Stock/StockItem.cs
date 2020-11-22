using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Stock
{
    public class StockItem
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string StockKeepingUnit { get; }

        public StockItem(string stockKeepingUnit)
        {
            Guard.Against.NullOrEmpty(stockKeepingUnit, nameof(stockKeepingUnit));

            StockKeepingUnit = stockKeepingUnit;
        }
    }
}
