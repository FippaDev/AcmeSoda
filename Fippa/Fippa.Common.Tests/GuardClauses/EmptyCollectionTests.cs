using System;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses;

[ExcludeFromCodeCoverage]
public class EmptyCollectionTests
{
    [Fact]
    public void EmptyCollection_IfInputIsAnEmptyCollection_ThrowsException()
    {
        var collection = Array.Empty<int>();
        Assert.Throws<ArgumentException>(() =>
            Guard.Against.EmptyCollection(collection, string.Empty));
    }

    [Fact]
    public void EmptyCollection_IfInputIsNotEmpty_DoesNothing()
    {
        var collection = new[] {33};
        Guard.Against.EmptyCollection(collection, string.Empty);
    }
}