using System;

namespace VendingLogic.Payments
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
