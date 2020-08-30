using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Exceptions;
using Models.Stock;

namespace Models.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SpiralDispenserModuleTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Constructor_GivenZeroSpirals_ThrowsException()
        {
            var spiralDispenserModule = new SpiralDispenserModule(0, new List<byte>(new byte[2]));
        }

        [TestMethod]
        public void Constructor_MatchingNumberOfItemsAndCodes_InitialiseStockArray()
        {
            var spiralDispenserModule = new SpiralDispenserModule(3, new List<byte>(new byte[] {100, 101, 102}));
        }

        [TestMethod]
        public void Dispense_WhenEmpty_Returns_NullObject()
        {
            var module = new SpiralDispenserModule(3, new List<byte>(new byte[] { 100, 101, 102 }));
            var stockItem = module.Dispense(100);
            Assert.AreEqual(typeof(NullObjectStockItem), stockItem.GetType());
        }

        [TestMethod, ExpectedException(typeof(InvalidProductIdentifierException))]
        public void Dispense_GivenInvalidIdentifier_ThrowsException()
        {
            var module = new SpiralDispenserModule(3, new List<byte>(new byte[] {100, 101, 102}));
            module.Dispense(0);
        }
    }
}
