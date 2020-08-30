using BusinessLogic.Payments;
using BusinessLogic.Selection;
using Fippa.Money.Payments;
using Models.Pricing;

namespace BusinessLogic
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        void AddPayment(IPayment payment);
        void CancelTransaction();
        SelectionResult MakeSelection(ushort selectionCode);

        EventHandler<BalanceChangedEvent>? BalanceChanged { get; set; }
        EventHandler<ItemDispensedNotificationEvent>? ItemDispensed { get; set; }
        void UpdatePriceList(PriceList priceList);
    }
}