namespace BusinessLogic.Payments
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
