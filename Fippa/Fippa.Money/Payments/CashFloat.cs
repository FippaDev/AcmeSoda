using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Money.Currencies;
using Fippa.Money.Exceptions;
using JetBrains.Annotations;

namespace Fippa.Money.Payments
{
    public class CashFloat<T> where T : IAcceptedCoins, new()
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

        public ushort AddCoins(ICashPayment coin, ushort quantity)
        {
            if (!_coins.ContainsKey(coin))
            {
                return quantity;
            }

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

        public void AddCoins(ICashPayment[] customerPayment)
        {
            if (ContainsUnsupportedCoins(customerPayment))
            {
                throw new ArgumentException("The customer payment contains some coins ");
            }

            foreach (var coin in customerPayment)
            {
                _coins[coin]++;
            }
        }

        private bool ContainsUnsupportedCoins(ICashPayment[] customerPayment)
        {
            return customerPayment.Any(coin => !_coins.ContainsKey(coin));
        }

        public Dictionary<ICashPayment, ushort> GetChange(decimal changeRequired)
        {
            var coinsToReturn = new Dictionary<ICashPayment, ushort>();
            var change = changeRequired;

            var currency = new T();
            foreach(var coin in currency.Collection().Reverse())
            {
                ushort coinsRequired = (ushort)(change / coin.Value);

                if (coinsRequired > 0 && _coins[coin] > 0)
                {
                    _coins[coin] -= coinsRequired;
                    coinsToReturn.Add(coin, coinsRequired);
                }

                change -= coinsRequired * coin.Value;
            }

            return coinsToReturn;
        }
    }
}