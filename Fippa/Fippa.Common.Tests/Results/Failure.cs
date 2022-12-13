using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results;

public class Failure
{
    private class TestError : IError
    {
    }

    [Fact]
    public void Constructor_GivenAnError_DoesNotThrowAnyException()
    {
        var result = new Fippa.Common.Results.Failure(new TestError());

        result.Error.Should().BeOfType(typeof(TestError));
        result.Successful.Should().Be(false);
    }
}