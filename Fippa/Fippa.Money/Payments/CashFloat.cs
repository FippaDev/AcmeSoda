using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using Fippa.Money.Currencies;
using Fippa.Money.Currencies.Sterling;

namespace Fippa.Money.Payments
{
    public class CashFloat<T> where T : ICurrency, new()
    {
        private class CoinStack
        {
            public IPayment Coin { get; private set; }
            public ushort Count { get; set; }

            public CoinStack(IPayment coin)
            {
                Coin = coin;
                Count = 0;
            }
        }

        private readonly List<CoinStack> _coins = new List<CoinStack>();

        public CashFloat()
        {
            var currency = new T();
            foreach (var coin in currency.Collection())
            {
                _coins.Add(new CoinStack(coin));
            }
        }

        public Collection<Coin> CalculateChangeToReturnToCustomer(decimal transactionTotal)
        {
            return new Collection<Coin>();
        }
    }
}