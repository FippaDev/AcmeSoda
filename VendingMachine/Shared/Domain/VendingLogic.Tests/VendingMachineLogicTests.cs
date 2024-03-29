﻿using System;
using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using Fippa.Money.Payments;
using Moq;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Dispenser;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainServices.Tests;

[ExcludeFromCodeCoverage]
public class VendingMachineLogicTests
{
    private readonly Mock<IPaymentModule<ICashPayment>> _mockCoinModule = new Mock<IPaymentModule<ICashPayment>>();
    private readonly Mock<IDispenserModule> _mockDispenserModule = new Mock<IDispenserModule>();

    [Fact]
    public void CancelTransaction_ResetsBalance()
    {
        var vendingMachine = new VendingMachineLogic(
            _mockDispenserModule.Object,
            _mockCoinModule.Object);

        vendingMachine.AddPayment(PoundSterling.TenPence);
        vendingMachine.CancelTransaction();

        Assert.Equal(0.00m, vendingMachine.Balance);
    }

    [Fact]
    public void AddPayment_GivenCashPayment_CallsAddOnThePaymentModule()
    {
        var vendingMachine = new VendingMachineLogic(
            _mockDispenserModule.Object,
            _mockCoinModule.Object);

        vendingMachine.AddPayment(PoundSterling.TenPence);

        _mockCoinModule.Verify(c => c.Add(PoundSterling.TenPence));
    }

    [Fact]
    public void AddPayment_CoinModuleGivenCardPayment_ThrowsGuardException()
    {
        var vendingMachine = new VendingMachineLogic(
            _mockDispenserModule.Object,
            _mockCoinModule.Object);

        Assert.Throws<ArgumentException>(() =>
            vendingMachine.AddPayment(new CardPayment(5.99m)));
    }
}