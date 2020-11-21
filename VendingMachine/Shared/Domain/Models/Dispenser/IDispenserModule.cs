using System;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IDispenserModule
    {
        BaseStockItem Dispense(string input);
        Tuple<SelectionResult, IDispenser> GetDispenser(string input);
        string GetStockReport();
    }
}