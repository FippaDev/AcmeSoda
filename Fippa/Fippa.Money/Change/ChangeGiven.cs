using System.Collections.Generic;
using Fippa.Common.Results;
using Fippa.Money.Currencies;

namespace Fippa.Money.Change
{
    public class ChangeGiven : Result<IEnumerable<GBP>>
    {
        protected internal ChangeGiven(IEnumerable<GBP> value)
            : base(value, null)
        {
        }
    }
}
