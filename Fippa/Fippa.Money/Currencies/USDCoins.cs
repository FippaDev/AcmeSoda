using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    [ExcludeFromCodeCoverage]
    public sealed class USDCoins : ICurrency
    {
        IEnumerable<ICashPayment> ICurrency.Collection()
        {
            return
                new[]
                {
                    USD.Cent,
                    USD.Nickel,
                    USD.Dime,
                    USD.Quarter,
                    USD.HalfDollar
                };
        }
    }
}
