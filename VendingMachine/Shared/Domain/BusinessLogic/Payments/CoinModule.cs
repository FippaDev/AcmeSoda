using Fippa.Money.Payments;

[assembly:InternalsVisibleTo("Models.Tests")]
[assembly:InternalsVisibleTo("BusinessLogic.Tests")]
namespace BusinessLogic.Payments
{
    internal class CoinModule : IPaymentModule<ICashPayment>
    {
        private readonly ObservableCollection<Coin> _coins = new ObservableCollection<Coin>();

        public EventHandler<MoneyAddedEvent>? MoneyAdded { get; set; }
        
        public CoinModule()
        {
            _coins.CollectionChanged += OnCoinCollectionChanged;
        }

        private void OnCoinCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                MoneyAdded?.Invoke(this, new MoneyAddedEvent(_coins.Last()));
            }
        }

        public decimal AmountDeposited
        {
            get { return _coins.Sum(c => c.Value); }
        }

        decimal IPaymentModule<Coin>.AmountDeposited { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(Coin coin)
        {
            _coins.Add(coin);
        }

        public void CancelTransaction()
        {
            _coins.Clear();
        }
    }
}
