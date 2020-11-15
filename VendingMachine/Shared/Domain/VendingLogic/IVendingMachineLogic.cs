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

        void AddPayment(PaymentCommand command);
        void AddProduct(ProductCommand command);
        SelectionResult MakeSelection(Selection.Selection selection);
        Tuple<ProductCommand, SelectionResult> IdentifyProductBySelectionCode(string selectionCode);
    }
}