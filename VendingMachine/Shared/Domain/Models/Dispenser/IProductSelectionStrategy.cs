using System;
using System.Collections.Generic;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IProductSelectionStrategy
    {
        Tuple<SelectionResult, BaseStockItem> FindProduct(IEnumerable<IDispenser> dispensers, ISelection selection);
        bool IsValid(IEnumerable<IDispenser> dispensers, ISelection selection);
    }
}