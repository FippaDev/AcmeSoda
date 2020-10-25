using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs
{
    [Serializable, ExcludeFromCodeCoverage]
    public class PriceListDto
    {
        // Key = SKU
        // Value = PriceListStockItem (with DisplayName and RRP)
        public Dictionary<string, PriceListStockItemDto> Items { get; set; }
    }
}
