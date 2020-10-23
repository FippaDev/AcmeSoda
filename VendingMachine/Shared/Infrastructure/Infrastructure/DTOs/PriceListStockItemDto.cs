using System;

namespace Infrastructure.DTOs
{
    [Serializable]
    public class PriceListStockItemDto
    {
        public string DisplayName { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
