using System;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.VendingLogic.Commands
{
    /// <summary>
    /// A product, with a negative monetary value. E.g. Can of soda @-1.50
    /// </summary>
    public class ProductCommand : Command
    {
        public ProductCommand(decimal value)
            : base(value)
        {
            Guard.Against.PositiveOrZero(value, nameof(value));
        }

        public ProductCommand(Selection.Selection selection)
            : base(selection.Price)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
