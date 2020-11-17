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
        public IDispenser FindProduct(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var dispenserCollection = dispensers as IDispenser[] ?? dispensers.ToArray();

            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.Null(selection, nameof(selection));

            DispenserSelection d = (DispenserSelection) selection;
            var dispenser = dispenserCollection.FirstOrDefault(dispenser => dispenser.Id == d.DispenserId);
            return
                dispenser != null
                    ? dispenser
                    : new NullDispenserObject();
        }

        public bool IsValid(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var s = selection as DispenserSelection;
            if (s == null)
            {
                throw new ArgumentException("Selection must be a DispenserSelection");
            }

            return dispensers.Any(d => d.Id == s.DispenserId);
        }
    }
}
