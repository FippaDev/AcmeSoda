using System;
using Fippa.Money.Payments;
using FluentAssertions;
using Xunit;

namespace Fippa.Money.Tests.Payments;

public class CardPaymentTests
{
    [Fact]
    public void Constructor_GivenNegativeAmount_ThrowsGuardException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var payment = new CardPayment(-3.99m);
        });
    }

    [Fact]
    public void Constructor_GivenZeroAmount_ThrowsGuardException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var payment = new CardPayment(0.00m);
        });
    }

    [Fact]
    public void Constructor_GivenPositiveAmount_ThrowsGuardException()
    {
        var payment = new CardPayment(0.01m);
        payment.Value.Should().Be(0.01m);
    }
}