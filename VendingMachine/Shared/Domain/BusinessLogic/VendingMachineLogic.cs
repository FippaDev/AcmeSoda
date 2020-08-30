using Ardalis.GuardClauses;
using BusinessLogic.Payments;
using BusinessLogic.Selection;
using Fippa.Money.Payments;
using Models.Pricing;

namespace BusinessLogic
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IPaymentModule<IPayment> _coinModule;
        private decimal _balance;

        private PriceList _priceList = new PriceList();

        public EventHandler<BalanceChangedEvent>? BalanceChanged { get; set; }
        public EventHandler<ItemDispensedNotificationEvent>? ItemDispensed { get; set; }

        public decimal Balance
        {
            get { return _balance; }

            private set
            {
                _balance = value;
                BalanceChanged?.Invoke(this, new BalanceChangedEvent(_balance));
            }
        }

        public VendingMachineLogic(IPaymentModule<IPayment> coinModule)
        {
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
            
            _coinModule.Add(payment);
        }

        public void CancelTransaction()
        {
            _coinModule.CancelTransaction();
            Balance = 0.00m;
        }

        public SelectionResult MakeSelection(ushort selectionCode)
        {
            if (!_priceList.Has(selectionCode))
            {
                return SelectionResult.InvalidSelection;
            }

            var selection = _priceList[selectionCode];

            if (Balance < selection.RetailPrice)
            {
                return SelectionResult.InsufficientFunds;
            }

            return ProcessTransaction(selection);
        }

        private SelectionResult ProcessTransaction(PriceListStockItem selection)
        {
            // TODO: Check the stock levels

            Balance -= selection.RetailPrice;

            BalanceChanged?.Invoke(this, new BalanceChangedEvent(Balance));
            ItemDispensed?.Invoke(this, new ItemDispensedNotificationEvent(selection.DisplayName));

            return SelectionResult.ValidSelection;
        }

        public void UpdatePriceList(PriceList priceList)
        {
            _priceList = priceList;
        }
    }
}
