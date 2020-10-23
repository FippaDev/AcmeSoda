using System;
using Fippa.Money.Payments;

namespace VendingMachine.Shared.Domain.VendingLogic.Payments
{
    public interface IPaymentModule<in T> where T : ICashPayment
    {
        EventHandler<MoneyAddedEvent> MoneyAdded { get; set; }

        void Add(T payment);
        void CancelTransaction();
    }
}
