using System.Collections.Generic;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace Domain.SupportedCurrencies
{
    public sealed class GBPCollection : ICurrency
    {
        IEnumerable<ICashPayment> ICurrency.Collection()
        {
            return
                new[]
                {
                    Fippa.Money.Currencies.GBP.FivePence,
                    Fippa.Money.Currencies.GBP.TenPence,
                    Fippa.Money.Currencies.GBP.TwentyPence,
                    Fippa.Money.Currencies.GBP.FiftyPence,
                    Fippa.Money.Currencies.GBP.OnePound,
                    Fippa.Money.Currencies.GBP.TwoPound
                };
        }
    }
}
