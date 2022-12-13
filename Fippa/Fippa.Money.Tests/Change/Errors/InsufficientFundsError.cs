using FluentAssertions;
using Xunit;

namespace Fippa.Money.Tests.Change.Errors
{
    public class InsufficientFundsError
    {
        [Fact]
        public void ToString_OutputsAsExpected()
        {
            var expected = "Requested £1.00 but only £0.99 is available.";

            var error = new Fippa.Money.Change.Errors.InsufficientFundsError(1.00m, 0.99m);

            error.ToString().Should().Be(expected);
        }
    }
}
