using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.DomainServices;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Commands;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Domain.Models.VendingMachine;

[assembly: InternalsVisibleTo("VendingMachine.Shared.Services.Tests")]
namespace VendingMachine.Shared.Services
{
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

        public void AddPayment(IPaymentCommand command)
        {
            _logic.AddPayment(command);
        }

        public void AddProduct(IProductCommand command)
        {
            _logic.AddProduct(command);
        }

        public SelectionResult MakeSelection(string input)
        {
            return _logic.MakeSelection(input);
        }

        public void ShowStockLevels(IStockReporting reportGenerator)
        {
            var stockReportData = _logic.GetStockReport(reportGenerator);
            var report = reportGenerator.GeneratCreateReport(stockReportData);
            _output.Show((IEnumerable<string>)report);
        }

        public void LoadPriceList(string filename)
        {
            _logic.PriceList = _priceListService.Load(filename);
        }

        public void LoadStock(string filename)
        {
            var items = _stockLoaderService.Load(filename);
            _logic.LoadInventory(items);
        }
    }
}