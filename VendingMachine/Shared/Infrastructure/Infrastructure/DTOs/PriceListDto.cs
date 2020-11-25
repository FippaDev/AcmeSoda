using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs
{
    [Serializable, ExcludeFromCodeCoverage]
    public class PriceListDto
    {
        // Key = StockKeepingUnit
        // Value = PriceListStockItem (with DisplayName and RRP)
        public List<PriceListStockItemDto> Items { get; set; }
    }
}
