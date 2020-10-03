using Ardalis.GuardClauses;

namespace Fippa.Money.Payments
{
    public class CardPayment : ICardPayment
    {
        public decimal Value { get; }

        public CardPayment(decimal amount)
        {
            Guard.Against.Negative(amount, nameof(Value));
            Value = amount;
        }
    }
}
