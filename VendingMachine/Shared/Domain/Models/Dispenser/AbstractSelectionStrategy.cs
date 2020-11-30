using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.Dispenser
{
    public class AbstractSelectionStrategy : ISelectionStrategy
    {
        public Tuple<SelectionResult, IDispenser> GetDispenser(IEnumerable<IDispenser> dispensers, string input)
        {
            var dispenserCollection = dispensers.ToList();
            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.NullOrEmpty(input, nameof(input));

            var validInput = ValidateInput(dispenserCollection, input);
            if (!validInput)
            {
                return new Tuple<SelectionResult, IDispenser>(
                    SelectionResult.InvalidSelection, new NullDispenserObject());
            }

            var dispenser = dispenserCollection.FirstOrDefault(SelectionPredicate(input));
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

        protected virtual Func<IDispenser, bool> SelectionPredicate(string input)
        {
            throw new NotImplementedException("Must be overriden.");
        }

        protected virtual bool ValidateInput(IEnumerable<IDispenser> dispensers, string input)
        {
            throw new NotImplementedException("Must be overriden.");
        }
    }
}
