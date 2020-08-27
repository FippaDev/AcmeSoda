using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    [ExcludeFromCodeCoverage]
    public sealed class GBPCoins : ICurrency
    {
        IEnumerable<ICashPayment> ICurrency.Collection()
        {
            return
                new[]
                {
                    GBP.OnePenny,
                    GBP.TwoPence,
                    GBP.FivePence,
                    GBP.TenPence,
                    GBP.TwentyPence,
                    GBP.FiftyPence,
                    GBP.OnePound,
                    GBP.TwoPound
                };
        }
    }
}
