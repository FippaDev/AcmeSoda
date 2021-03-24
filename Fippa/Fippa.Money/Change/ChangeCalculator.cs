using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Fippa.Common.Results;
using Fippa.Money.Change.Errors;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace Fippa.Money.Change
{
    public class ChangeCalculator<T> where T : ICashPayment
    {
        public ChangeCalculator(CashFloat<GBPCoins> cashFloat)
        {
        }

        public Result GetChange(IEnumerable<T> coinsIn, decimal purchase)
        {
            var coinsOut = new Collection<T>();
            decimal coinsInSum = coinsIn.Sum(c => c.Value);
            if (purchase > coinsInSum)
            {
                return Result.Fail(new InsufficientFundsError());
            }

            return Result.Success(coinsOut);
        }
    }
}
