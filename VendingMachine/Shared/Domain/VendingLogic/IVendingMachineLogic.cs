using System;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        void UpdatePriceList(PriceList priceList);
        void AddDeposit(PaymentCommand command);
        void AddPurchase(ProductCommand command);
        SelectionResult MakeSelection(string selectionCode);
        Tuple<ProductCommand, SelectionResult> IdentifyProductBySelectionCode(string selectionCode);
    }
}