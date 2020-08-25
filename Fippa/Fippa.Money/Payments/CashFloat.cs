using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fippa.Money.Currencies;

namespace Fippa.Money.Payments
{
    public class CashFloat<T> where T : ICurrency, new()
    {
        private readonly Dictionary<IPayment, ushort> _coins = new Dictionary<IPayment, ushort>();

        public CashFloat()
        {
            var currency = new T();
            foreach (var coin in currency.Collection().OrderByDescending(c => c.Value))
            {
                _coins.Add(coin, 0);
            }
        }

        public decimal Balance => _coins.Sum(c => c.Key.Value * c.Value);

        public Collection<IPayment> CalculateChangeToReturnToCustomer(decimal transactionTotal)
        {
            return new Collection<IPayment>();
        }

        public void AddCoinsToCashFloat(IPayment coin, ushort quantity)
        {
            _coins[coin] += quantity;
        }
    }
}