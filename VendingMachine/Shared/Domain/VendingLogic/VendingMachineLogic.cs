using System;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private decimal _balance;

        private PriceList _priceList;
        private IDispenserModule _dispenserModule;

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
        }

        public void CancelTransaction()
        {
            _coinModule.CancelTransaction();
            Balance = 0.00m;
        }

        public SelectionResult MakeSelection(string selectionCode)
        {
            if (!_dispenserModule.IsValidSelectionCode(selectionCode))
            {
                return SelectionResult.InvalidSelection;
            }

            var stockItem = _dispenserModule.QuerySpiral(selectionCode);

            var selectedItem = _priceList.GetItem(stockItem.StockKeepingUnit);

            if (Balance < selectedItem.RetailPrice)
            {
                return SelectionResult.InsufficientFunds;
            }

            return ProcessTransaction(selectionCode, selectedItem);
        }

        private SelectionResult ProcessTransaction(string selectionCode, PriceListStockItem selectedItem)
        {
            // TODO: Check the stock levels

            Balance -= selectedItem.RetailPrice;

            BalanceChanged?.Invoke(this, new BalanceChangedEvent(Balance));

            _dispenserModule.Dispense(selectionCode);

            return SelectionResult.ValidSelection;
        }

        public void UpdatePriceList(PriceList priceList)
        {
            _priceList = priceList;
        }

        public void With(IDispenserModule dispenserModule)
        {
            _dispenserModule = dispenserModule;
        }
    }
}
