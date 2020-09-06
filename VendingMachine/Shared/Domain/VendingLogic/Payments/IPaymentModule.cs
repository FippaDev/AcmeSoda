using System;
using Fippa.Money.Payments;

namespace VendingLogic.Payments
{
    public interface IPaymentModule<T> where T : ICashPayment
    {
        decimal AmountDeposited { get; }

        EventHandler<MoneyAddedEvent> MoneyAdded { get; set; }

        void Add(T payment);
        void CancelTransaction();
    }
}
