using System;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using Models;
using Models.Pricing;
using VendingLogic.Payments;
using VendingLogic.Selection;

namespace VendingLogic
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IDispenserModule _dispenserModule;
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private decimal _balance;

        private PriceList _priceList = new PriceList();

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
            BalanceChanged?.Invoke(this, new BalanceChangedEvent(Balance));
        }

        public void AddPayment(IPayment payment)
        {
            Guard.Against.Null(payment, nameof(payment));
            
            _coinModule.Add((ICashPayment)payment);
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
