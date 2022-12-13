using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ardalis.GuardClauses;
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
            Guard.Against.Null(cashFloat, nameof(cashFloat));
        }

        public IResult GetChange(IEnumerable<T> coinsIn, decimal purchase)
        {
            Guard.Against.Null(coinsIn, nameof(coinsIn));

            var coinsOut = new Collection<T>();
            decimal coinsInSum = coinsIn.Sum(c => c.Value);
            if (purchase > coinsInSum)
            {
                return new Failure(new InsufficientFundsError(purchase, coinsInSum));
            }

            return new Success<Collection<T>>(coinsOut);
        }
    }
}
