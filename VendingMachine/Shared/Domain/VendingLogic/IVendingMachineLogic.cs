using System;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        void AddPayment(IPayment payment);
        void CancelTransaction();
        SelectionResult MakeSelection(string selectionCode);

        EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        void UpdatePriceList(PriceList priceList);
        void With(IDispenserModule dispenserModule);
    }
}