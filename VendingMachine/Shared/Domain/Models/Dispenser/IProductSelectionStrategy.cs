using System;
using System.Collections.Generic;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface IProductSelectionStrategy
    {
        Tuple<SelectionResult, IDispenser> ValidateSelection(IEnumerable<IDispenser> dispensers, ISelection selection);
    }
}