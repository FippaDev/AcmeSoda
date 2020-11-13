using System;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.VendingLogic.Commands
{
    /// <summary>
    /// A representative payment (coin or card payment). E.g. 0.25
    /// </summary>
    public class PaymentCommand : Command
    {
        public PaymentCommand(decimal value)
            : base(value)
        {
            Guard.Against.NegativeOrZero(value, nameof(value));
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
