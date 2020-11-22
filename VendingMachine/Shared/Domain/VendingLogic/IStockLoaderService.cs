using System.Collections.ObjectModel;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IStockLoaderService
    {
        ReadOnlyCollection<InventoryItem> Load(string filename);
    }
}
