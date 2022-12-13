using System.Collections.Generic;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace VendingMachine.Shared.Domain.Models.Currencies
{
    public sealed class AcceptedPoundSterlingCoins : IAcceptedCoins
    {
        public IEnumerable<ICashPayment> Collection()
        {
            return
                new[]
                {
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
