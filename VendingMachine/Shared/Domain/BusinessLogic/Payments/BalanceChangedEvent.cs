namespace BusinessLogic.Payments
{
    public class BalanceChangedEvent : EventArgs
    {
        public decimal Balance { get; }

        public BalanceChangedEvent(decimal balance)
        {
            Balance = balance;
        }
    }
}
