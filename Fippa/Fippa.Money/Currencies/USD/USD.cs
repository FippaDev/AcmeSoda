using System.Collections.Generic;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies.USD
{
    public sealed class USD : ICurrency
    {
        public static Coin Parse(string valueString)
        {
            if (decimal.TryParse(valueString, out var value)
                &&
                Coin.TryFromValue(value, out var coin))
            {
                return coin;
            }

            return Coin.InvalidCoin;
        }

        IEnumerable<ICashPayment> ICurrency.Collection()
        {
            return
                new[]
                {
                    Coin.Nickel,
                    Coin.Dime,
                    Coin.Quarter,
                    Coin.HalfDollar
                };
        }
    }
}
