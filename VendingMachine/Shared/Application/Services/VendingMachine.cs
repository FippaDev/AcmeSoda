using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;

[assembly: InternalsVisibleTo("VendingMachine.Shared.Services.Tests")]
namespace VendingMachine.Shared.Services
{
    public class VendingMachine : IVendingMachine
    {
        private readonly IVendingMachineLogic _logic;
        private readonly IUserOutput _output;
        private readonly IPriceListService _priceListService;
        private readonly IStockLoaderService _stockLoaderService;
        private readonly IStockReporting _stockReporting;

        public string Manufacturer { get; }
 
        public VendingMachine(IUserOutput output,
            IPriceListService priceListService,
            IStockLoaderService stockLoaderService,
            IStockReporting stockReporting,
            IVendingMachineLogic logic,
            string manufacturer)
        {
            _output = output;
            _logic = logic;
            _priceListService = priceListService;
            _stockLoaderService = stockLoaderService;
            _stockReporting = stockReporting;

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

        public void AddPayment(PaymentCommand command)
        {
            _logic.AddPayment(command);
        }

        public void AddProduct(ProductCommand command)
        {
            _logic.AddProduct(command);
        }

        public SelectionResult MakeSelection(string input)
        {
            return _logic.MakeSelection(input);
        }

        public void ShowStockLevels()
        {
            _stockReporting.ShowStockReport(_logic.GetStockReport());
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