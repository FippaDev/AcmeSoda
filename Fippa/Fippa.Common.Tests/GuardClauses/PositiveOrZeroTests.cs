using System;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses
{
    public class PositiveOrZeroTests
    {
        [Theory]
        [InlineData(-1.00)]
        [InlineData(0.00)]
        public void GreaterThanZero_Scenarios_AsExpected(decimal given)
        {
            Assert.Throws<ArgumentException>(() =>
                Guard.Against.PositiveOrZero(given, string.Empty));
        }

        [Fact]
        public void GreaterThanZero_IfNegative_DoesNothing()
        {
            Assert.Throws<ArgumentException>(() =>
                Guard.Against.PositiveOrZero(-1, string.Empty));
        }
    }
}
