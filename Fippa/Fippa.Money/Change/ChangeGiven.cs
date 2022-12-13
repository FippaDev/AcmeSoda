using System.Collections.Generic;
using Fippa.Common.Results;
using Fippa.Money.Currencies;

namespace Fippa.Money.Change
{
    public class ChangeGiven : Success<IEnumerable<PoundSterling>>
    {
        protected internal ChangeGiven(IEnumerable<PoundSterling> value)
            : base(value)
        {
        }
    }
}
