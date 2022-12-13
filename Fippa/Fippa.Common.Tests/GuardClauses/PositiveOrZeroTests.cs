using System;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses;

public class PositiveOrZeroTests
{
    [Theory]
    [InlineData(1.00)]
    [InlineData(0.00)]
    public void PositiveOrZero_Scenarios_ThrowException(decimal given)
    {
        Assert.Throws<ArgumentException>(() =>
            Guard.Against.PositiveOrZero(given, string.Empty));
    }

    [Theory]
    [InlineData(-1.00)]
    public void PositiveOrZero_IfNegative_DoesNothing(decimal given)
    {
        Guard.Against.PositiveOrZero(given, string.Empty);
    }
}