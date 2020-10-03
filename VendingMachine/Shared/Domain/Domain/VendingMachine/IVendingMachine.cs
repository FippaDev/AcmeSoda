using Fippa.Money.Payments;
using VendingLogic.Selection;

namespace Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void AddPayment(IPayment payment);
        SelectionResult MakeSelection(ushort selectionCode);
    }
}
