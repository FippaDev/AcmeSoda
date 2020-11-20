using Fippa.Common.Extensions.system;
using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(false, null)]
        [InlineData(false, "")]
        [InlineData(false, " ")]
        [InlineData(true, "!")]
        public void HasValue_Scenarios_AsExpected(bool expected, string given)
        {
            expected.Should().Be(given.HasValue(), $"Expected {expected} when given '{given}'");
        }
    }
}
