using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.DomainServices
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private decimal _balance;

        private readonly IDispenserModule _dispenserModule;

        private readonly List<IPayment> _deposits = new List<IPayment>();
        private readonly List<StockItem> _purchases = new List<StockItem>();

        public PriceList PriceList { get; set; }
        public EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        public decimal Balance
        {
            get => _balance;

            private set
            {
                _balance = value;
                BalanceChanged?.Invoke(this, new BalanceChangedEvent(_balance));
            }
        }

        public VendingMachineLogic(
            IDispenserModule dispenserModule,
            IPaymentModule<ICashPayment> coinModule)
        {
            _dispenserModule = dispenserModule;
            _coinModule = coinModule;

            _coinModule.MoneyAdded += OnMoneyAdded;
        }

        private void OnMoneyAdded(object sender, MoneyAddedEvent e)
        {
            Balance += e.Amount;
        }

        public void AddPayment(IPayment payment)
        {
            Guard.Against.Null(payment, nameof(payment));
            var cashPayment = payment as ICashPayment;

            if (cashPayment == null)
            {
                throw new ArgumentException("Only cash payments are accepted. There is no card module");
            }

            _coinModule.Add(cashPayment);
            Balance += cashPayment.Value;
        }

        public void CancelTransaction()
        {
            _coinModule.CancelTransaction();
            Balance = 0.00m;
        }

        public void AddProduct(StockItem item)
        {
            _purchases.Add(item);
            var lookup = PriceList.GetProductDetails(item.StockKeepingUnit);
            Balance -= lookup.RetailPrice;
        }

        public SelectionResult MakeSelection(string input)
        {
            var result = _dispenserModule.GetDispenser(input);
            var selectionResult = result.Item1;
            var dispenser = result.Item2;

            if (selectionResult == SelectionResult.ValidSelection)
            {
                var rrp = PriceList.LookupByStockKeepingUnit(dispenser.StockItem.StockKeepingUnit);
                _purchases.Add(new StockItem(dispenser.StockItem.StockKeepingUnit));
            }

            return selectionResult;
        }

        public void LoadInventory(IEnumerable<InventoryItem> items)
        {
            _dispenserModule.Load(items);
        }

        public ReadOnlyCollection<StockReportLine> GetStockReport(IStockReporting reportGenerator)
        {
            return _dispenserModule.GetStockReport(reportGenerator, PriceList);
        }
    }
}
