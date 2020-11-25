using System;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs
{
    [Serializable, ExcludeFromCodeCoverage]
    public class InventoryItemDto
    {
        public ushort DispenserId { get; set; }
        public ushort Quantity { get; set; }
        public string StockKeepingUnit { get; set; }
    }
}
