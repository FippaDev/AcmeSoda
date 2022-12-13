using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Selection
{
    public class ProductSelection : ISelection
    {
        public string StockKeepingUnit { get; }

        public ProductSelection(string stockKeepingUnit)
        {
            Guard.Against.NullOrWhiteSpace(stockKeepingUnit, nameof(stockKeepingUnit));
            StockKeepingUnit = stockKeepingUnit;
        }
    }
}
