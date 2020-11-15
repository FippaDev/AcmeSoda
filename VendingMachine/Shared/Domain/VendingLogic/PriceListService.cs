using System.Collections.Generic;
using Infrastructure;
using Infrastructure.DTOs;
using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class PriceListService : IPriceListService
    {
        private readonly IDataLoader<PriceListDto> _dataLoader;
        private PriceList _priceList = new PriceList(new List<PriceListStockItem>());

        public PriceListService(IDataLoader<PriceListDto> dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public void Load(string filename)
        {
            var dto = _dataLoader.Load(filename);
            var items = new List<PriceListStockItem>();
            foreach (var item in dto.Items)
            {
                items.Add(
                    new PriceListStockItem(
                        item.Key,
                        item.Value.DisplayName,
                        item.Value.RetailPrice));
            }

            _priceList = new PriceList(items);
        }

        public decimal PriceLookup(string sku)
        {
            return _priceList.PriceLookup(sku);
        }
    }
}
