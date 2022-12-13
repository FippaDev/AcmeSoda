using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs;
// Key = StockKeepingUnit
// Value = PriceListStockItem (with DisplayName and RRP)

[Serializable, ExcludeFromCodeCoverage]
public class PriceListDto
{
    public List<PriceListStockItemDto> Items { get; set; } = new List<PriceListStockItemDto>();
}