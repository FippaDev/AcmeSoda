using System;
using Fippa.Money.Payments;
using VendingLogic.Payments;
using VendingLogic.Selection;

namespace Services
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        decimal Balance { get; }
        EventHandler<BalanceChangedEvent>? BalanceChanged { get; set; }
        EventHandler<ItemDispensedNotificationEvent>? ItemDispensed { get; set; }

        void AddPayment(IPayment payment);
        SelectionResult MakeSelection(ushort selectionCode);
    }
}
