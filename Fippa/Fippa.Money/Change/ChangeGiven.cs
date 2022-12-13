using System.Collections.Generic;
using Fippa.Common.Results;
using Fippa.Money.Currencies;

namespace Fippa.Money.Change
{
    public class ChangeGiven : Success<IEnumerable<GBP>>
    {
        protected internal ChangeGiven(IEnumerable<GBP> value)
            : base(value)
        {
        }
    }
}
