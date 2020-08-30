﻿using System;
using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Pricing;
using Moq;
using VendingLogic;
using VendingLogic.Admin;

namespace Services.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VendingMachineTests
    {
        private readonly Mock<IObjectSerializer<PriceList>> _mockSerializer = new Mock<IObjectSerializer<PriceList>>();
        private readonly Mock<IVendingMachineLogic> _mockLogic = new Mock<IVendingMachineLogic>();
        private readonly Mock<IAdminModule> _mockAdminModule = new Mock<IAdminModule>();

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void VendingMachine_WithEmptyManufacturerName_ThrowsException()
        {
            var vendingMachine = new VendingMachine(_mockSerializer.Object, _mockLogic.Object, _mockAdminModule.Object, string.Empty);
        }

        [TestMethod]
        public void VendingMachine_GivenManufacturer_SetsProperty()
        {
            var pepsiMachine = new VendingMachine(_mockSerializer.Object, _mockLogic.Object, _mockAdminModule.Object, "Pepsi");
            Assert.AreEqual("Pepsi", pepsiMachine.Manufacturer);
        }
    }
}
