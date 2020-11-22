using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Infrastructure;
using Infrastructure.DTOs;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class StockLoaderService : IStockLoaderService
    {
        private readonly IDispenserModule _dispenserModule;
        private readonly IDataLoader<InventoryDto> _dataLoader;

        public StockLoaderService(IDispenserModule dispenserModule, IDataLoader<InventoryDto> dataLoader)
        {
            _dispenserModule = dispenserModule;
            _dataLoader = dataLoader;
        }

        public ReadOnlyCollection<InventoryItem> Load(string filename)
        {
            Guard.Against.Null(_dispenserModule, nameof(_dispenserModule));

            if (!_dispenserModule.IsEmpty)
            {
                throw new InvalidOperationException("Cannot import a stockLoaderService unless all dispensers are empty.");
            }

            var items = new List<InventoryItem>();
            foreach (var item in _dataLoader.Load(filename).Items)
            {
                ushort dispenserId = item.Key;
                var inventoryItem = item.Value;
                items.Add(
                    new InventoryItem(
                        dispenserId,
                        inventoryItem.SKU,
                        item.Value.Quantity));
            }

            return items.AsReadOnly();
        }
    }
}
