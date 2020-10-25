using FluentAssertions;
using VendingMachine.Shared.Domain.Models.AdminAccess;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.AdminAccess
{
    public class AdminAccountTests
    {
        [Fact]
        public void Constructor_RequiresAuthentication_AlwaysTrue()
        {
            string userToken = "abc123";
            var key = new AdminAccount(userToken);
            key.RequiresAuthentication.Should().Be(true);
        }

        [Fact]
        public void UserToken_Setter_ValueCopiedToProperty()
        {
            string userToken = "abc123";
            var key = new AdminAccount(userToken);
            key.UserToken.Should().Be(userToken);
        }
    }
}
