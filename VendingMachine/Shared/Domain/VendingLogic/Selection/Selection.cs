using Fippa.Common.Extensions.system;

namespace VendingMachine.Shared.Domain.VendingLogic.Selection
{
    public class Selection
    {
        // Identifies the dispenser
        public string Code { get; }
        // Product identifier
        public string SKU { get; }
        // Price
        public decimal Price { get; }

        public Selection(string code, string sku, decimal price)
        {
            Code = code;
            SKU = sku;
            Price = price;
        }

        public bool IsValid => Code.HasValue() && SKU.HasValue() && Price.GreaterThanZero();
    }
}
