using VendingMachine.Shared.Domain.Models.Commands;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void Initialise();
        void AddPayment(IPaymentCommand command);
        void AddProduct(IProductCommand command);

        SelectionResult MakeSelection(string input);
        void ShowStockLevels(IStockReporting reportGenerator);
        void LoadPriceList(string filename);
        void LoadStock(string filename);
    }
}
