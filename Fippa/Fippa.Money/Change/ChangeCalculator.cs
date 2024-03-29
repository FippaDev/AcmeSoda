﻿using System.Collections.Generic;
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
        public ChangeCalculator(CashFloat<PoundSterlingCoins> cashFloat)
        {
            Guard.Against.Null(cashFloat, nameof(cashFloat));
        }

        public IResult GetChange(IEnumerable<T> coinsIn, decimal purchase)
        {
            var coins = coinsIn as T[] ?? coinsIn.ToArray();
            Guard.Against.Null(coins, nameof(coinsIn));

            var coinsOut = new Collection<T>();
            decimal coinsInSum = coins.Sum(c => c.Value);
            if (purchase > coinsInSum)
            {
                return new Failure(new InsufficientFundsError(purchase, coinsInSum));
            }

            return new Success<Collection<T>>(coinsOut);
        }
    }
}
