using System.Diagnostics.CodeAnalysis;
using VendingMachine.Shared.Domain.Models.Stock;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Dispenser;

[ExcludeFromCodeCoverage]
public class DispenserTests
{
    private const ushort SpiralCapacity = 10;

    [Fact]
    public void Constructor_MatchingNumberOfItemsAndCodes_InitialisesStockArray()
    {
        var spiralDispenser = new Models.Dispenser.Dispenser(0, SpiralCapacity);
    }

    [Fact]
    public void Dispense_WhenEmpty_ReturnsNullObject()
    {
        var dispenser = new Models.Dispenser.Dispenser(0, SpiralCapacity);
        var stockItem = dispenser.Dispense();
        Assert.Equal(typeof(NullObjectStockItem), stockItem.GetType());
    }

    [Fact]
    public void AddStockItem_WhilstLessThanMaxCapacity_AddsStockItemAndReturnsTrue()
    {
        var dispenser = new Models.Dispenser.Dispenser(0, SpiralCapacity);
        bool added = dispenser.AddStockItem(new StockItem("Mars"));

        Assert.True(added);
        Assert.Equal((uint)1, dispenser.StockCount());
    }

    [Fact]
    public void AddStockItem_WhenFull_CannotAddAnyMoreItemsAndReturnsFalse()
    {
        var dispenser = new Models.Dispenser.Dispenser(0, SpiralCapacity);

        for (int i = 0; i < Models.Dispenser.Dispenser.MaxCapacity; i++)
        {
            dispenser.AddStockItem(new StockItem("SW01"));
        }

        bool added = dispenser.AddStockItem(new StockItem("SW01"));

        Assert.False(added);
        Assert.Equal(Models.Dispenser.Dispenser.MaxCapacity, dispenser.StockCount());
    }

    [Fact]
    public void AddStockItem_AddingDifferentTypesToTheQueue_ReturnsItemsInCorrectOrder()
    {
        var dispenser = new Models.Dispenser.Dispenser(0, SpiralCapacity);
        dispenser.AddStockItem(new StockItem("SW01"));
        dispenser.AddStockItem(new StockItem("CR01"));
            
        Assert.Equal((uint)2, dispenser.StockCount());
        var item1 = dispenser.Dispense();
        Assert.Equal(typeof(StockItem), item1.GetType());
        var item2 = dispenser.Dispense();
        Assert.Equal(typeof(StockItem), item2.GetType());
    }
}