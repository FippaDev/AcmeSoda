using System.Collections.Generic;
using System.Collections.ObjectModel;
using Infrastructure;
using Infrastructure.DTOs;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.DomainServices
{
    public class StockLoaderService : IStockLoaderService
    {
        private readonly IDataLoader<InventoryDto> _dataLoader;

        public StockLoaderService(IDataLoader<InventoryDto> dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public ReadOnlyCollection<InventoryItem> Load(string filename)
        {
            var items = new List<InventoryItem>();
            foreach (var item in _dataLoader.Load(filename).Items)
            {
                items.Add(
                    new InventoryItem(
                        item.DispenserId,
                        item.StockKeepingUnit,
                        item.Quantity));
            }

            return items.AsReadOnly();
        }
    }
}
