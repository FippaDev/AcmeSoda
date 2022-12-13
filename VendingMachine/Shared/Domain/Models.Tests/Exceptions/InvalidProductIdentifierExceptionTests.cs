using System;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.Exceptions;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Exceptions;

public class InvalidProductIdentifierExceptionTests
{
    [Fact]
    public void Constructor_withNullMessage_ThrowsGuardException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var ex = new InvalidProductIdentifierException("");
        });
    }

    [Fact]
    public void Constructor_withStringMessage_SetMessage()
    {
        var ex = new InvalidProductIdentifierException("Test");
        ex.Message.Should().Be("Test");
    }
}