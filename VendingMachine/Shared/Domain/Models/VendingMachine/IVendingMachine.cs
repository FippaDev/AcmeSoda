using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.VendingMachine;

public interface IVendingMachine
{
    string Manufacturer { get; }

    void Initialise();
    void AddPayment(IPayment payment);
    void AddProduct(StockItem item);

    SelectionResult MakeSelection(string input);
    void ShowStockLevels(IStockReporting reportGenerator);
    void LoadPriceList(string filename);
    void LoadStock(string filename);
}