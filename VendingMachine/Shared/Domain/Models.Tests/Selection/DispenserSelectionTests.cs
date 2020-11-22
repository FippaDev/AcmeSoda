using FluentAssertions;
using VendingMachine.Shared.Domain.Models.Selection;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Selection
{
    public class DispenserSelectionTests
    {
        [Fact]
        public void Constructor_GivenString_SetsStockKeepingUnit()
        {
            ushort id = 33;
            var selection = new DispenserSelection(id);

            selection.DispenserId.Should().Be(id);
        }
    }
}
