using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Selection
{
    public class ProductSelection : ISelection
    {
        public string SKU { get; }

        public ProductSelection(string sku)
        {
            Guard.Against.NullOrWhiteSpace(sku, nameof(sku));
            SKU = sku;
        }
    }
}
