using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    [ExcludeFromCodeCoverage]
    public sealed class PoundSterlingCoins : IAcceptedCoins
    {
        IEnumerable<ICashPayment> IAcceptedCoins.Collection()
        {
            return
                new[]
                {
                    PoundSterling.OnePenny,
                    PoundSterling.TwoPence,
                    PoundSterling.FivePence,
                    PoundSterling.TenPence,
                    PoundSterling.TwentyPence,
                    PoundSterling.FiftyPence,
                    PoundSterling.OnePound,
                    PoundSterling.TwoPound
                };
        }
    }
}
