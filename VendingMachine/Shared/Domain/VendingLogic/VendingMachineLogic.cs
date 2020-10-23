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
        private readonly IDispenserModule _dispenserModule;
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private decimal _balance;

        private PriceList _priceList;

        public EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }
        public EventHandler<ItemDispensedNotificationEvent> ItemDispensed { get; set; }

        public decimal Balance
        {
            get { return _balance; }

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

        public SelectionResult MakeSelection(ushort selectionCode)
        {
            if (!_dispenserModule.IsValidSelectionCode(selectionCode))
            {
                return SelectionResult.InvalidSelection;
            }

            var sku = _dispenserModule.GetStockKeepingUnitCode(selectionCode);
            var selectedItem = _priceList.GetItem(sku);

            if (Balance < selectedItem.RetailPrice)
            {
                return SelectionResult.InsufficientFunds;
            }

            return ProcessTransaction(selectedItem);
        }

        private SelectionResult ProcessTransaction(PriceListStockItem selectedItem)
        {
            // TODO: Check the stock levels

            Balance -= selectedItem.RetailPrice;

            BalanceChanged?.Invoke(this, new BalanceChangedEvent(Balance));
            ItemDispensed?.Invoke(this, new ItemDispensedNotificationEvent(selectedItem));

            return SelectionResult.ValidSelection;
        }

        public void UpdatePriceList(PriceList priceList)
        {
            _priceList = priceList;
        }
    }
}
