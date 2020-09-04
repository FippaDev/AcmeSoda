using System.Diagnostics.CodeAnalysis;
using Models.Stock;
using Xunit;

namespace Models.Tests
{
    [ExcludeFromCodeCoverage]
    public class SpiralDispenserTests
    {
        [Fact]
        public void Constructor_MatchingNumberOfItemsAndCodes_InitialisesStockArray()
        {
            new SpiralDispenser();
        }

        [Fact]
        public void Dispense_WhenEmpty_ReturnsNullObject()
        {
            var dispenser = new SpiralDispenser();
            var stockItem = dispenser.Dispense();
            Assert.Equal(typeof(NullObjectStockItem), stockItem.GetType());
        }

        [Fact]
        public void AddStockItem_WhilstLessThanMaxCapacity_AddsStockItemAndReturnsTrue()
        {
            var dispenser = new SpiralDispenser();
            bool added = dispenser.AddStockItem(new Confectionery("CHOC_WISPA"));

            Assert.True(added);
            Assert.Equal((uint)1, dispenser.StockCount());
        }

        [Fact]
        public void AddStockItem_WhenFull_CannotAddAnyMoreItemsAndReturnsFalse()
        {
            var dispenser = new SpiralDispenser();

            for (int i = 0; i < SpiralDispenser.MaxCapacity; i++)
            {
                dispenser.AddStockItem(new Confectionery("SW01"));
            }

            bool added = dispenser.AddStockItem(new Confectionery("SW01"));

            Assert.False(added);
            Assert.Equal((uint)SpiralDispenser.MaxCapacity, dispenser.StockCount());
        }

        [Fact]
        public void AddStockItem_AddingDifferentTypesToTheQueue_ReturnsItemsInCorrectOrder()
        {
            var dispenser = new SpiralDispenser();
            dispenser.AddStockItem(new Confectionery("SW01"));
            dispenser.AddStockItem(new Crisps("CR01"));
            
            Assert.Equal((uint)2, dispenser.StockCount());
            var item1 = dispenser.Dispense();
            Assert.Equal(typeof(Confectionery), item1.GetType());
            var item2 = dispenser.Dispense();
            Assert.Equal(typeof(Crisps), item2.GetType());
        }
    }
}
