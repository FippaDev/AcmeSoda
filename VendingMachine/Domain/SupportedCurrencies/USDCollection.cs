using System.Collections.Generic;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace Domain.SupportedCurrencies
{
    public sealed class USDCollection : ICurrency
    {
        IEnumerable<ICashPayment> ICurrency.Collection()
        {
            return
                new[]
                {
                    Fippa.Money.Currencies.USD.Nickel,
                    Fippa.Money.Currencies.USD.Dime,
                    Fippa.Money.Currencies.USD.Quarter,
                    Fippa.Money.Currencies.USD.HalfDollar
                };
        }
    }
}
