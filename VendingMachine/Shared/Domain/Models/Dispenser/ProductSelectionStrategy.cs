using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Dispenser;

/// <summary>
/// Customers can select a product from a selection code (e.g. A3 on a spiral dispenser)
/// </summary>
public class ProductSelectionStrategy : AbstractSelectionStrategy
{
    protected override Func<IDispenser, bool> SelectionPredicate(string input)
    {
        return dispenser => dispenser.StockItem.StockKeepingUnit == input;
    }

    protected override bool ValidateInput(IEnumerable<IDispenser> dispensers, string input)
    {
        Guard.Against.NullOrEmpty(input, nameof(input));

        var dispenser = dispensers.FirstOrDefault(SelectionPredicate(input));
        return dispenser != null;
    }
}