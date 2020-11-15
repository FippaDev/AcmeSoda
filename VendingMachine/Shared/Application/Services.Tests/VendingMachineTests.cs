using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserInterface;
using VendingMachine.Shared.Domain.VendingLogic;

namespace VendingMachine.Shared.Services.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IUserOutput> _mockOutput = new Mock<IUserOutput>();
        private readonly Mock<IVendingMachineLogic> _mockLogic = new Mock<IVendingMachineLogic>();

        [TestMethod]
        public void VendingMachine_WithEmptyManufacturerName_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new VendingMachine(
                    _mockOutput.Object,
                    _mockLogic.Object,
                    string.Empty);
            });
        }

        [TestMethod]
        public void VendingMachine_GivenManufacturer_SetsManufacturerProperty()
        {
            var pepsiMachine = new VendingMachine(
                _mockOutput.Object,
                _mockLogic.Object,
                "Pepsi");

            Assert.AreEqual("Pepsi", pepsiMachine.Manufacturer);
        }
    }
}
