using System;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs
{
    [Serializable, ExcludeFromCodeCoverage]
    public class PriceListStockItemDto
    {
        public string DisplayName { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
