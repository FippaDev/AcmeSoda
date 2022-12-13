using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Dispenser;

/// <summary>
/// Customers can select a product from a selection code (e.g. A3 on a spiral dispenser)
/// </summary>
public class DispenserSelectionStrategy : AbstractSelectionStrategy
{
    protected override Func<IDispenser, bool> SelectionPredicate(string input)
    {
        var id = ushort.Parse(input);
        return dispenser => dispenser.Id == id;
    }

    protected override bool ValidateInput(IEnumerable<IDispenser> dispensers, string input)
    {
        Guard.Against.NullOrEmpty(input, nameof(input));

        return 
            ushort.TryParse(input, out var selection)
            &&
            dispensers.Any(d => d.Id == selection);
    }
}