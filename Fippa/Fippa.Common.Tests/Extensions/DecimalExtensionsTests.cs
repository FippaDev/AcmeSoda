using Fippa.Common.Extensions.system;
using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(false, -1.00)]
        [InlineData(false, 0.00)]
        [InlineData(true, 1.01)]
        public void GreaterThanZero_Scenarios_AsExpected(bool expected, decimal given)
        {
            Assert.Equal(expected, given.GreaterThanZero());
        }

        [Theory]
        [InlineData(false, -1.00)]
        [InlineData(false, 1.00)]
        [InlineData(true, 0.00)]
        public void IsZero_Scenarios_AsExpected(bool expected, decimal given)
        {
            expected.Should().Be(given.IsZero(), $"Expected {expected} when given '{given}'");
        }
    }
}
