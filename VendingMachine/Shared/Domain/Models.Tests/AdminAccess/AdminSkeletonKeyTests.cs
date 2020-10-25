using FluentAssertions;
using VendingMachine.Shared.Domain.Models.AdminAccess;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.AdminAccess
{
    public class AdminSkeletonKeyTests
    {
        [Fact]
        public void Constructor_RequiresAuthentication_AlwaysTrue()
        {
            var key = new AdminSkeletonKey();
            key.RequiresAuthentication.Should().Be(false);
        }
    }
}
