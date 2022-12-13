using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Stock;

public class StockItem
{
    /// <summary>
    /// StockKeepingUnit
    /// </summary>
    public string StockKeepingUnit { get; }

    public StockItem(string stockKeepingUnit)
    {
        Guard.Against.NullOrEmpty(stockKeepingUnit, nameof(stockKeepingUnit));

        StockKeepingUnit = stockKeepingUnit;
    }
}