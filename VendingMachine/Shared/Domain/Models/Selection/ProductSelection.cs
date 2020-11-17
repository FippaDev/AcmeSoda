namespace VendingMachine.Shared.Domain.Models.Selection
{
    public class ProductSelection : ISelection
    {
        public string SKU { get; }

        public ProductSelection(string sku)
        {
            SKU = sku;
        }
    }
}
