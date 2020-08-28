using System.Collections.Generic;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public interface IAcceptedCoins
    {
        IEnumerable<ICashPayment> Collection();
    }
}
