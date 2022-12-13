using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    [ExcludeFromCodeCoverage]
    public sealed class UnitedStateDollarCoins : IAcceptedCoins
    {
        IEnumerable<ICashPayment> IAcceptedCoins.Collection()
        {
            return
                new[]
                {
                    UnitedStatesDollar.Cent,
                    UnitedStatesDollar.Nickel,
                    UnitedStatesDollar.Dime,
                    UnitedStatesDollar.Quarter,
                    UnitedStatesDollar.HalfDollar
                };
        }
    }
}
