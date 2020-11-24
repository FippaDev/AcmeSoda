namespace VendingMachine.Shared.Domain.Models.Stock
{
    public class InventoryItem
    {
        public InventoryItem(ushort dispenserId, string sku, ushort quantity)
        {
            DispenserId = dispenserId;
            SKU = sku;
            Quantity = quantity;
        }

        public ushort DispenserId { get; set; }
        public string SKU { get; set; }
        public ushort Quantity { get; set; }
    }
}
