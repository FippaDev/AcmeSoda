using System.Collections.Generic;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies.Sterling
{
    public sealed class Sterling : ICurrency
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
                    Coin.FivePence,
                    Coin.TenPence,
                    Coin.TwentyPence,
                    Coin.FiftyPence,
                    Coin.OnePound,
                    Coin.TwoPound
                };
        }
    }
}
