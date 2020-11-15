using System;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void Initialise();
        void AddPayment(PaymentCommand command);
        void AddProduct(ProductCommand command);
        Tuple<SelectionResult, Selection> ValidateSelection(string selectionCode);
    }
}
