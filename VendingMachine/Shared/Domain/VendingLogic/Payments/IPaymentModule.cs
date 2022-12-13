using System;
using Fippa.Money.Payments;

namespace VendingMachine.Shared.Domain.DomainServices.Payments
{
    public interface IPaymentModule<in T> where T : ICashPayment
    {
        EventHandler<MoneyAddedEvent>? MoneyAdded { get; set; }

        void Add(T payment);
        void CancelTransaction();
    }
}
