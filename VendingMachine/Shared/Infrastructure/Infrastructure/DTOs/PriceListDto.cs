using System;
using System.Collections.Generic;

namespace Infrastructure.DTOs
{
    [Serializable]
    public class PriceListDto
    {
        // Key = SKU
        // Value = PriceListStockItem (with DisplayName and RRP)
        public Dictionary<string, PriceListStockItemDto> Items { get; set; }
    }
}
