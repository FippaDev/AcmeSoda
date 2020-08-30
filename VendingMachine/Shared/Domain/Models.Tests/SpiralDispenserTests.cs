using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Stock;

namespace Models.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SpiralDispenserTests
    {
         [TestMethod]
        public void Constructor_MatchingNumberOfItemsAndCodes_InitialisesStockArray()
        {
            new SpiralDispenser();
        }

        [TestMethod]
        public void Dispense_WhenEmpty_ReturnsNullObject()
        {
            var dispenser = new SpiralDispenser();
            var stockItem = dispenser.Dispense();
            Assert.AreEqual(typeof(NullObjectStockItem), stockItem.GetType());
        }

        [TestMethod]
        public void AddStockItem_WhilstLessThanMaxCapacity_AddsStockItemAndReturnsTrue()
        {
            var dispenser = new SpiralDispenser();
            bool added = dispenser.AddStockItem(new Confectionery("CHOC_WISPA"));

            Assert.IsTrue(added);
            Assert.AreEqual((uint)1, dispenser.StockCount());
        }

        [TestMethod]
        public void AddStockItem_WhenFull_CannotAddAnyMoreItemsAndReturnsFalse()
        {
            var dispenser = new SpiralDispenser();

            for (int i = 0; i < SpiralDispenser.MaxCapacity; i++)
            {
                dispenser.AddStockItem(new Confectionery("SW01"));
            }

            bool added = dispenser.AddStockItem(new Confectionery("SW01"));

            Assert.IsFalse(added);
            Assert.AreEqual((uint)SpiralDispenser.MaxCapacity, dispenser.StockCount());
        }

        [TestMethod]
        public void AddStockItem_AddingDifferentTypesToTheQueue_ReturnsItemsInCorrectOrder()
        {
            var dispenser = new SpiralDispenser();
            dispenser.AddStockItem(new Confectionery("SW01"));
            dispenser.AddStockItem(new Crisps("CR01"));
            
            Assert.AreEqual((uint)2, dispenser.StockCount());
            var item1 = dispenser.Dispense();
            Assert.AreEqual(typeof(Confectionery), item1.GetType());
            var item2 = dispenser.Dispense();
            Assert.AreEqual(typeof(Crisps), item2.GetType());
        }
    }
}
