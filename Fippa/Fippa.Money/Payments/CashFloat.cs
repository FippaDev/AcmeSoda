using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fippa.Money.Currencies;

namespace Fippa.Money.Payments
{
    public class CashFloat<T> where T : ICurrency, new()
    {
        private readonly Dictionary<ICashPayment, ushort> _coins = new Dictionary<ICashPayment, ushort>();
        private readonly ushort _maxCoinsPerDenomination;

        public CashFloat(ushort maxCoinsPerDenomination)
        {
            _maxCoinsPerDenomination = maxCoinsPerDenomination;
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
            int freeSpace = _maxCoinsPerDenomination - currentQuantity;
            ushort excessCoins = 0;

            if(quantity <= freeSpace)
            {
                _coins[coin] += quantity;
            }
            else
            {
                _coins[coin] = _maxCoinsPerDenomination;
                excessCoins = (ushort)(quantity - freeSpace);
            }

            return excessCoins;
        }
    }
}