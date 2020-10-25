using System;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.AdminAccess;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.AdminAccess
{
    public class InvalidAccessTokenTests
    {
        [Fact]
        public void Constructor_IdentificationGuid_SetToEmpty()
        {
            var key = new InvalidAccessToken();
            key.Token.Should().Be(Guid.Empty);
        }
    }
}
