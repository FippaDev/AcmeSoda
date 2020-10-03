using System;
using Ardalis.GuardClauses;

namespace VendingLogic.Payments
{
    public class BalanceChangedEvent : EventArgs
    {
        public decimal Balance { get; }

        public BalanceChangedEvent(decimal balance)
        {
            Guard.Against.Negative(balance, nameof(balance));
            Balance = balance;
        }
    }
}
