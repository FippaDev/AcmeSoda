using VendingMachine.Shared.Domain.Models.Commands;
using VendingMachine.Shared.Domain.Models.Selection;

namespace VendingMachine.Shared.Domain.Models.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void Initialise();
        void AddPayment(IPaymentCommand command);
        void AddProduct(IProductCommand command);

        SelectionResult MakeSelection(string input);
        void ShowStockLevels();
        void LoadPriceList(string filename);
        void LoadStock(string filename);
    }
}
