using System.Collections.Generic;
using Infrastructure;
using Infrastructure.DTOs;
using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class PriceListService : IPriceListService
    {
        private readonly IDataLoader<PriceListDto> _dataLoader;

        public PriceListService(IDataLoader<PriceListDto> dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public PriceList Load(string filename)
        {
            var dto = _dataLoader.Load(filename);
            var items = new List<PriceListStockItem>();
            foreach (var item in dto.Items)
            {
                items.Add(
                    new PriceListStockItem(
                        item.StockKeepingUnit,
                        item.DisplayName,
                        item.RetailPrice));
            }

            return new PriceList(items);
        }
    }
}
