﻿using System;
using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests.Payments
{
    public class BalanceChangedEventTests
    {
        [Fact]
        public void BalanceChangedEvent_InitialisingWithNegativeBalance_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new BalanceChangedEvent(-1.00m));
        }

        [Fact]
        public void Balance_ReturnsConstructorParameter()
        {
            var b = new BalanceChangedEvent(1.50m);
            Assert.Equal(1.50m, b.Balance);
        }
    }
}
