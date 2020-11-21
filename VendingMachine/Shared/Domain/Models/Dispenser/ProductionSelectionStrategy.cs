using System;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    /// <summary>
    /// Customers select by product, allowing the machine to select the 
    /// </summary>
    public class ProductSelectionStrategy : AbstractSelectionStrategy
    {
        protected override Func<IDispenser, bool> SelectionPredicate(ISelection selection)
        {
            var s = (ProductSelection) selection;
            return dd => dd.StockItem.StockKeepingUnit == s.SKU;
        }
    }
}
