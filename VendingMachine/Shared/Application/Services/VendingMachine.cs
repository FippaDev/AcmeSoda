using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.DomainServices;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Domain.Models.VendingMachine;

[assembly: InternalsVisibleTo("VendingMachine.Shared.Services.Tests")]
namespace VendingMachine.Shared.Services;

public class VendingMachine : IVendingMachine
{
    private readonly IVendingMachineLogic _logic;
    private readonly IUserOutput _output;
    private readonly IPriceListService _priceListService;
    private readonly IStockLoaderService _stockLoaderService;

    public string Manufacturer { get; }
 
    public VendingMachine(IUserOutput output,
        IPriceListService priceListService,
        IStockLoaderService stockLoaderService,
        IVendingMachineLogic logic,
        string manufacturer)
    {
        _output = output;
        _logic = logic;
        _priceListService = priceListService;
        _stockLoaderService = stockLoaderService;

        Guard.Against.NullOrEmpty(manufacturer, nameof(manufacturer));
        Manufacturer = manufacturer;

        _logic.BalanceChanged += OnBalanceChanged;
    }

    private void OnBalanceChanged(object sender, BalanceChangedEvent e)
    {
        _output.ShowBalance(_logic.Balance);
    }

    public void Initialise()
    {
        _output.ShowWelcomeMessage(Manufacturer);
    }

    public void AddPayment(IPayment payment)
    {
        _logic.AddPayment(payment);
    }

    public void AddProduct(StockItem item)
    {
        _logic.AddProduct(item);
    }

    public SelectionResult MakeSelection(string input)
    {
        return _logic.MakeSelection(input);
    }

    public void ShowStockLevels(IStockReporting reportGenerator)
    {
        var stockReportData = _logic.GetStockReport(reportGenerator);
        var report = (IEnumerable<string>)reportGenerator.CreateReport(stockReportData);
        _output.Show(report);
    }

    public void LoadPriceList(string filename)
    {
        _logic.InitialisePriceList(_priceListService.Load(filename));
    }

    public void LoadStock(string filename)
    {
        var items = _stockLoaderService.Load(filename);
        _logic.LoadInventory(items);
    }
}