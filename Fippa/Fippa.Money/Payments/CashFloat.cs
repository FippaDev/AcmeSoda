using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fippa.Money.Currencies;

namespace Fippa.Money.Payments
{
    public class CashFloat<T> where T : ICurrency, new()
    {
        private readonly Dictionary<ICashPayment, ushort> _coins = new Dictionary<ICashPayment, ushort>();
        private readonly ushort MaxCoinsPerDenomination;

        public CashFloat(ushort maxCoinsPerDenomination)
        {
            MaxCoinsPerDenomination = maxCoinsPerDenomination;
            var currency = new T();
            foreach (var coin in currency.Collection().OrderByDescending(c => c.Value))
            {
                _coins.Add(coin, 0);
            }
        }

        public decimal Balance => _coins.Sum(c => c.Key.Value * c.Value);

        public Collection<ICashPayment> CalculateChangeToReturnToCustomer(decimal transactionTotal)
        {
            return new Collection<ICashPayment>();
        }

        public ushort AddCoinsToCashFloat(ICashPayment coin, ushort quantity)
        {
            ushort currentQuantity = _coins[coin];
            int freeSpace = MaxCoinsPerDenomination - currentQuantity;
            ushort excess = 0;

            if(quantity <= freeSpace)
            {
                _coins[coin] += quantity;
            }
            else
            {
                _coins[coin] = MaxCoinsPerDenomination;
                excess = (ushort)(quantity - freeSpace);
            }

            return excess;
        }
    }
}