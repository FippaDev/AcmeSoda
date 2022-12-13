namespace VendingMachine.Shared.Domain.Models.Stock
{
    public class InventoryItem
    {
        public InventoryItem(ushort dispenserId, string stockKeepingUnit, ushort quantity)
        {
            DispenserId = dispenserId;
            StockKeepingUnit = stockKeepingUnit;
            Quantity = quantity;
        }

        public ushort DispenserId { get; set; }
        public string StockKeepingUnit { get; set; }
        public ushort Quantity { get; set; }
    }
}
