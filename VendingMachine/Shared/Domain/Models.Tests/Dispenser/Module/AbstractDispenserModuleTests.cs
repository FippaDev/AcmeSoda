using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Dispenser.Modules;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Dispenser.Module
{
    public class AbstractDispenserModuleTests
    {
        private class TestDispenserModule : AbstractDispenserModule
        {
            public TestDispenserModule(ISelectionStrategy selectionStrategy) 
                : base(selectionStrategy)
            {
            }
        }

        [Fact]
        public void Constructor_IsEmpty_InitiallyTrue()
        {
            var mockSelectionStrategy = new Mock<ISelectionStrategy>();
            var module = new TestDispenserModule(mockSelectionStrategy.Object);
            module.IsEmpty.Should().Be(true);
        }

        [Fact]
        public void Dispense_WithValidInput_CallsDispense()
        {
            const string sku = "sku001";
            var mockDispenser = new Mock<IDispenser>();
            mockDispenser.Setup(d => d.Dispense()).Returns(new StockItem(sku));

            var mockSelectionStrategy = new Mock<ISelectionStrategy>();
            mockSelectionStrategy
                .Setup(s => s.GetDispenser(It.IsAny<IEnumerable<IDispenser>>(), "A"))
                .Returns(new Tuple<SelectionResult,IDispenser>(
                    SelectionResult.ValidSelection,
                    mockDispenser.Object));

            var module = new TestDispenserModule(mockSelectionStrategy.Object);
            var dispensedItem = module.Dispense("A");

            mockDispenser.Verify(d => d.Dispense(), Times.Once);
            dispensedItem.StockKeepingUnit.Should().Be(sku);
        }
    }
}
