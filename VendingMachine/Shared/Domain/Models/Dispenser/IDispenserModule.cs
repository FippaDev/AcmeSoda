using System.Collections.ObjectModel;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IDispenserModule
    {
        ReadOnlyCollection<string> GetSelectionCodes();
        BaseStockItem IdentifyProductBySelectionCode(string selectionCode);
        BaseStockItem Dispense(string selectionCode);
        bool IsValidSelectionCode(string selectionCode);
    }
}