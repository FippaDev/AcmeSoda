using System;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    /// <summary>
    /// Customers can select a product from a selection code (e.g. A3 on a spiral dispenser)
    /// </summary>
    public class OneToOneStrategy : AbstractSelectionStrategy, IProductSelectionStrategy
    {
        protected override Func<IDispenser, bool> SelectionPredicate(ISelection selection)
        {
            var d = (DispenserSelection)selection;
            return dispenser => dispenser.Id == d.DispenserId;
        }
    }
}
