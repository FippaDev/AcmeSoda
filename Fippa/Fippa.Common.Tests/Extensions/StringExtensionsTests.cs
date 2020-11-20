using Fippa.Common.Extensions.system;
using Xunit;

namespace Fippa.Common.Tests.Extensions
{
    public class DecimalExtensionsTests
    {
        [Theory]
        [InlineData(false, -1.00)]
        [InlineData(false, 0.00)]
        [InlineData(true, 1.01)]
        public void GreaterThanZero_Scenarios_AsExpected(bool expected, decimal given)
        {
            Assert.Equal(expected, given.GreaterThanZero());
        }
    }
}
