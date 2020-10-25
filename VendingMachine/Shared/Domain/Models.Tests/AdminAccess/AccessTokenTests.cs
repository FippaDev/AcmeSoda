using System;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.AdminAccess;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.AdminAccess
{
    public class AccessTokenTests
    {
        [Fact]
        public void IsValid_WhenTokenGuidIsEmpty_ReturnsFalse()
        {
            var token = new AccessToken(Guid.Empty);
            token.IsValid.Should().Be(false);
        }

        [Fact]
        public void IsValid_WhenTokenGuidIsNotEmpty_ReturnsTrue()
        {
            var token = new AccessToken(new Guid("CE154CC7-045B-43FE-8927-A32D0C8E422C"));
            token.IsValid.Should().Be(true);
        }
    }
}
