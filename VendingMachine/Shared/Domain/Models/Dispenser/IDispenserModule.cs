using System;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IDispenserModule
    {
        BaseStockItem Dispense(ISelection selection);
        Tuple<SelectionResult, IDispenser> ValidateSelection(ISelection selection);
    }
}