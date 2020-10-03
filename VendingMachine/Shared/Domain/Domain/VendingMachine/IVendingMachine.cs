using System;
using Fippa.Money.Payments;
using VendingLogic.Payments;
using VendingLogic.Selection;

namespace Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        EventHandler<ItemDispensedNotificationEvent> ItemDispensed { get; set; }

        void AddPayment(IPayment payment);
        SelectionResult MakeSelection(ushort selectionCode);
        void ShowBalance();
    }
}
