using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results;

public class SuccessGeneric
{
    [Fact]
    public void Constructor_WithString_DoesNotThrowAnyException()
    {
        var result = new Fippa.Common.Results.Success<string>("testValue");

        result.Successful.Should().Be(true);
        result.Value.Should().Be("testValue");
    }

    [Fact]
    public void Constructor_WithInt_DoesNotThrowAnyException()
    {
        var result = new Fippa.Common.Results.Success<int>(42);

        result.Successful.Should().Be(true);
        result.Value.Should().Be(42);
    }
}