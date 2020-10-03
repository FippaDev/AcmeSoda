using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Models.Exceptions;
using Models.Stock;
using Xunit;

namespace Models.Tests
{
    [ExcludeFromCodeCoverage]
    public class SpiralDispenserModuleTests
    {
        [Fact]
        public void Constructor_GivenZeroSpirals_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var spiralDispenserModule = new SpiralDispenserModule(0);
            });
        }

        [Fact]
        public void Constructor_MatchingNumberOfItemsAndCodes_InitialiseStockArray()
        {
            var spiralDispenserModule = new SpiralDispenserModule(3);
        }

        [Fact]
        public void Dispense_WhenEmpty_Returns_NullObject()
        {
            var module = new SpiralDispenserModule(3);
            var stockItem = module.Dispense(100);
            Assert.Equal(typeof(NullObjectStockItem), stockItem.GetType());
        }

        [Fact]
        public void Dispense_GivenInvalidIdentifier_ThrowsException()
        {
            Assert.Throws<InvalidProductIdentifierException>(() =>
            {
                var module = new SpiralDispenserModule(3);
                module.Dispense(0);
            });
        }
    }
}
