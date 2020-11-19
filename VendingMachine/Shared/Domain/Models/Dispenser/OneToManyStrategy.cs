using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    /// <summary>
    /// Customers select by product, allowing the machine to select the 
    /// </summary>
    public class OneToManyStrategy : IProductSelectionStrategy
    {
        public Tuple<SelectionResult, IDispenser> ValidateSelection(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var dispenserCollection = dispensers as IDispenser[] ?? dispensers.ToArray();

            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.Null(selection, nameof(selection));

            ProductSelection s = (ProductSelection)selection;
            var dispenser = dispenserCollection.FirstOrDefault(dd => dd.StockItem.StockKeepingUnit == s.SKU);

            if (dispenser == null)
            {
                return new Tuple<SelectionResult, IDispenser>(SelectionResult.InvalidSelection, new NullDispenserObject());
            }

            var stockCount = dispenser.StockCount();
            if (stockCount == 0)
            {
                return new Tuple<SelectionResult, IDispenser>(SelectionResult.OutOfStock, new NullDispenserObject());
            }

            return new Tuple<SelectionResult, IDispenser>(SelectionResult.ValidSelection, dispenser);
        }
    }
}
