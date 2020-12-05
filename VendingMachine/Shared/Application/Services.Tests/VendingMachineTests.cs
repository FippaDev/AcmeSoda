using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VendingMachine.Shared.Domain.DomainServices;

namespace VendingMachine.Shared.Services.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IUserOutput> _mockOutput = new Mock<IUserOutput>();
        private readonly Mock<IPriceListService> _mockPriceListService = new Mock<IPriceListService>();
        private readonly Mock<IStockLoaderService> _mockStockLoaderService = new Mock<IStockLoaderService>();
        private readonly Mock<IVendingMachineLogic> _mockLogic = new Mock<IVendingMachineLogic>();
        private readonly Mock<IStockReporting> _mockStockReporting = new Mock<IStockReporting>();

        [TestMethod]
        public void VendingMachine_WithEmptyManufacturerName_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new VendingMachine(
                    _mockOutput.Object,
                    _mockPriceListService.Object,
                    _mockStockLoaderService.Object,
                    _mockStockReporting.Object,
                    _mockLogic.Object,
                    string.Empty);
            });
        }

        [TestMethod]
        public void VendingMachine_GivenManufacturer_SetsManufacturerProperty()
        {
            var pepsiMachine = new VendingMachine(
                _mockOutput.Object,
                _mockPriceListService.Object,
                _mockStockLoaderService.Object,
                _mockStockReporting.Object,
                _mockLogic.Object,
                "Pepsi");

            Assert.AreEqual("Pepsi", pepsiMachine.Manufacturer);
        }
    }
}
