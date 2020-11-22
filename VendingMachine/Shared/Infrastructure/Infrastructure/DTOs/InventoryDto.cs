using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs
{
    [Serializable, ExcludeFromCodeCoverage]
    public class InventoryDto
    {
        // Key = Dispenser Id
        // Value = InventoryItem (dispenser id, SKU, quantity)
        public Dictionary<ushort, InventoryItemDto> Items { get; set; }
    }
}
