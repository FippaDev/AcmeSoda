using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using Fippa.Money.Payments;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.VendingLogic.Tests")]
namespace VendingMachine.Shared.Domain.DomainServices.Payments
{
    public class CoinModule : IPaymentModule<ICashPayment>
    {
        private readonly ObservableCollection<IPayment> _coins = new ObservableCollection<IPayment>();

        public EventHandler<MoneyAddedEvent> MoneyAdded { get; set; }
        
        public CoinModule()
        {
            _coins.CollectionChanged += OnCoinCollectionChanged;
        }

        private void OnCoinCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
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
