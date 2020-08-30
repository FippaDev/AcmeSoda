using Fippa.Money.Payments;

namespace BusinessLogic.Payments
{
    public interface IPaymentModule<T> where T : ICashPayment
    {
        decimal AmountDeposited { get; set; }

        EventHandler<MoneyAddedEvent>? MoneyAdded { get; set; }

        void Add(T payment);
        void CancelTransaction();
    }
}
