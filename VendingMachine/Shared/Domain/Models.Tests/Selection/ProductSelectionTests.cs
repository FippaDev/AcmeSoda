using System;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.Selection;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Selection;

public class ProductSelectionTests
{
    [Fact]
    public void Constructor_GivenEmptyString_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            new ProductSelection(""));
    }

    [Fact]
    public void Constructor_GivenWhitespaceString_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            new ProductSelection("   "));
    }

    [Fact]
    public void Constructor_GivenString_SetsStockKeepingUnit()
    {
        var sku = "CHOC01";
        var selection = new ProductSelection(sku);

        selection.StockKeepingUnit.Should().Be(sku);
    }
}