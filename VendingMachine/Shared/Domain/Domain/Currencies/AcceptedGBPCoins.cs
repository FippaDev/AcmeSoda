using System.Collections.Generic;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace VendingMachine.Shared.Domain.Domain.Currencies
{
    public sealed class AcceptedGBPCoins : IAcceptedCoins
    {
        public IEnumerable<ICashPayment> Collection()
        {
            return
                new[]
                {
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
