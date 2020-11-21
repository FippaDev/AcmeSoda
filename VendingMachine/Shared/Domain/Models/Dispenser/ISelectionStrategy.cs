using System;
using System.Collections.Generic;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public interface ISelectionStrategy
    {
        Tuple<SelectionResult, IDispenser> GetDispenser(IEnumerable<IDispenser> dispensers, string input);
    }
}