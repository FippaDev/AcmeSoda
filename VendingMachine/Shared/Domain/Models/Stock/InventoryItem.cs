namespace VendingMachine.Shared.Domain.Models.Stock
{
    public class InventoryItem
    {
        public InventoryItem(ushort dispenserId, string sKU, ushort quantity)
        {
            DispenserId = dispenserId;
            SKU = sKU;
            Quantity = quantity;
        }

        public ushort DispenserId { get; set; }
        public string SKU { get; set; }
        public ushort Quantity { get; set; }
    }
}
