using System;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.Stock;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Stock;

public class StockReportLineTests
{
    [Fact]
    public void Constructor_GivenEmptyDisplayName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var line = new StockReportLine(0, "", 1.99m, 4);
        });
    }

    [Fact]
    public void Constructor_GivenNegativePrice_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new StockReportLine(0, "Chocolate", -1.99m, 4);
        });
    }

    [Fact]
    public void Constructor_SetsValues()
    {
        var line = new StockReportLine(1, "Chocolate", 1.99m, 4);

        line.DispenserId.Should().Be(1);
        line.DisplayName.Should().Be("Chocolate");
        line.Price.Should().Be(1.99m);
        line.StockLevel.Should().Be(4);
    }
}