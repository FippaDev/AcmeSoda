using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Stock;

public class StockReportLine
{
    public ushort DispenserId { get; }
    public string DisplayName { get; }
    public decimal Price { get; }
    public ushort StockLevel { get; }

    public StockReportLine(
        ushort dispenserId,
        string displayName,
        decimal price,
        ushort stockLevel)
    {
        Guard.Against.NullOrEmpty(displayName, nameof(displayName));
        Guard.Against.NegativeOrZero(price, nameof(price));

        DispenserId = dispenserId;
        DisplayName = displayName;
        Price = price;
        StockLevel = stockLevel;
    }
}