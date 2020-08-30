using System;
using Fippa.Money.Payments;
using Models.Pricing;
using VendingLogic.Payments;
using VendingLogic.Selection;

namespace VendingLogic
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        void AddPayment(IPayment payment);
        void CancelTransaction();
        SelectionResult MakeSelection(ushort selectionCode);

        EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }
        EventHandler<ItemDispensedNotificationEvent> ItemDispensed { get; set; }
        void UpdatePriceList(PriceList priceList);
    }
}