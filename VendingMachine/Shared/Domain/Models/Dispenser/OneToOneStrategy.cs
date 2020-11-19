using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    /// <summary>
    /// Customers can select a product from a selection code (e.g. A3 on a spiral dispenser)
    /// </summary>
    public class OneToOneStrategy : IProductSelectionStrategy
    {
        public Tuple<SelectionResult, IDispenser> ValidateSelection(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var dispenserCollection = dispensers as IDispenser[] ?? dispensers.ToArray();

            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.Null(selection, nameof(selection));

            DispenserSelection d = (DispenserSelection) selection;
            var dispenser = dispenserCollection.FirstOrDefault(dispenser => dispenser.Id == d.DispenserId);

            if (dispenser == null)
            {
                return new Tuple<SelectionResult, IDispenser>(SelectionResult.InvalidSelection, new NullDispenserObject());
            }

            var stockCount = dispenser.StockCount();
            if (stockCount ==  0)
            {
                return new Tuple<SelectionResult, IDispenser>(SelectionResult.OutOfStock, new NullDispenserObject());
            }

            return new Tuple<SelectionResult, IDispenser>(SelectionResult.ValidSelection, dispenser);
        }
    }
}
