using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void AddPayment(IPayment payment);
        SelectionResult MakeSelection(string selectionCode);
    }
}
