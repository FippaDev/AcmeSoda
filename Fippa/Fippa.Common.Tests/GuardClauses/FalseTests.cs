using System;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses;

[ExcludeFromCodeCoverage]
public class FalseTests
{
    [Fact]
    public void False_IfInputIsFalse_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            Guard.Against.ExpressionBeingFalse(false, string.Empty));
    }

    [Fact]
    public void False_IfInputIsTrue_NoExceptionThrown()
    {
        Guard.Against.ExpressionBeingFalse(true, string.Empty);
    }
}