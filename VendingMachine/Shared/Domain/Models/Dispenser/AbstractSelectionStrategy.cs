using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class AbstractSelectionStrategy
    {
        public Tuple<SelectionResult, IDispenser> ValidateSelection(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var dispenserCollection = dispensers as IDispenser[] ?? dispensers.ToArray();

            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.Null(selection, nameof(selection));

            var dispenser = dispenserCollection.FirstOrDefault(SelectionPredicate(selection));

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

        protected virtual Func<IDispenser, bool> SelectionPredicate(ISelection selection)
        {
            throw new NotImplementedException();
        }
    }
}
