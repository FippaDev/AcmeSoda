using System;

namespace VendingMachine.Shared.Domain.DomainServices.Payments
{
    public class MoneyAddedEvent : EventArgs
    {
        public decimal Amount { get; }

        public MoneyAddedEvent(decimal amount)
        {
            Amount = amount;
        }
    }
}
