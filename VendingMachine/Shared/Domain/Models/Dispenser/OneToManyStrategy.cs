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
        public IDispenser FindProduct(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var dispenserCollection = dispensers as IDispenser[] ?? dispensers.ToArray();

            Guard.Against.Null(dispenserCollection, nameof(dispensers));
            Guard.Against.EmptyCollection(dispenserCollection, nameof(dispensers));
            Guard.Against.Null(selection, nameof(selection));

            ProductSelection s = (ProductSelection)selection;
            var dispenser = dispenserCollection.FirstOrDefault(dispenser => dispenser.StockItem.StockKeepingUnit.Equals(s.SKU));
            return
                dispenser != null
                    ? dispenser
                    : new NullDispenserObject();
        }

        public bool IsValid(IEnumerable<IDispenser> dispensers, ISelection selection)
        {
            var s = selection as ProductSelection;
            if (s == null)
            {
                throw new ArgumentException("Selection must be a ProductSelection");
            }

            return dispensers.Any(d => d.StockItem.StockKeepingUnit == s.SKU);
        }
    }
}
