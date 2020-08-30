using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using Fippa.Money.Payments;

[assembly:InternalsVisibleTo("Models.Tests")]
[assembly:InternalsVisibleTo("BusinessLogic.Tests")]
namespace VendingLogic.Payments
{
    internal class CoinModule : IPaymentModule<ICashPayment>
    {
        private readonly ObservableCollection<IPayment> _coins = new ObservableCollection<IPayment>();

        public EventHandler<MoneyAddedEvent> MoneyAdded { get; set; }
        
        public CoinModule()
        {
            _coins.CollectionChanged += OnCoinCollectionChanged;
        }

        private void OnCoinCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                MoneyAdded?.Invoke(this, new MoneyAddedEvent(_coins.Last().Value));
            }
        }

        public decimal AmountDeposited
        {
            get { return _coins.Sum(c => c.Value); }
        }

        decimal IPaymentModule<ICashPayment>.AmountDeposited { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(ICashPayment coin)
        {
            _coins.Add(coin);
        }

        public void CancelTransaction()
        {
            _coins.Clear();
        }
    }
}
