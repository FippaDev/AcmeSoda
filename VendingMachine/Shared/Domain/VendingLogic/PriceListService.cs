using System.Linq;
using Infrastructure;
using Infrastructure.DTOs;
using VendingMachine.Shared.Domain.Models.Pricing;

namespace VendingMachine.Shared.Domain.DomainServices
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
            return new PriceList(
                dto.Items
                    .Select(item =>
                        new PriceListStockItem(
                            item.StockKeepingUnit,
                            item.DisplayName,
                            item.RetailPrice))
                    .ToList());
        }
    }
}
