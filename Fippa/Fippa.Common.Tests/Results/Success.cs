using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results;

public class Success
{
    [Fact]
    public void Constructor_DoesNotThrowAnyException()
    {
        var result = new Fippa.Common.Results.Success();

        result.Successful.Should().Be(true);
    }
}