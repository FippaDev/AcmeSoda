using System;
using System.Diagnostics.CodeAnalysis;
using Infrastructure;
using Infrastructure.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserInterface;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Admin;

namespace VendingMachine.Shared.Services.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IUserOutput> _mockOutput = new Mock<IUserOutput>();
        private readonly Mock<IDataLoader<PriceListDto>> _mockDataLoader = new Mock<IDataLoader<PriceListDto>>();
        private readonly Mock<IVendingMachineLogic> _mockLogic = new Mock<IVendingMachineLogic>();
        private readonly Mock<IAdminModule> _mockAdminModule = new Mock<IAdminModule>();

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void VendingMachine_WithEmptyManufacturerName_ThrowsException()
        {
            var vendingMachine = new VendingMachine(
                _mockOutput.Object,
                _mockDataLoader.Object,
                _mockLogic.Object,
                _mockAdminModule.Object,
                string.Empty);
        }

        [TestMethod]
        public void VendingMachine_GivenManufacturer_SetsManufacturerProperty()
        {
            var pepsiMachine = new VendingMachine(
                _mockOutput.Object,
                _mockDataLoader.Object,
                _mockLogic.Object,
                _mockAdminModule.Object,
                "Pepsi");

            Assert.AreEqual("Pepsi", pepsiMachine.Manufacturer);
        }
    }
}
