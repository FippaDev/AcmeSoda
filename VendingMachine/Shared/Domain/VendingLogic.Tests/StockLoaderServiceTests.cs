using System.Collections.Generic;
using FluentAssertions;
using Infrastructure;
using Infrastructure.DTOs;
using Moq;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainServices.Tests
{
    public class StockLoaderServiceTests
    {
        private readonly Mock<IDataLoader<InventoryDto>> _mockLoader = new Mock<IDataLoader<InventoryDto>>();

        [Fact]
        public void Load_ReadFromEmptyFile_ReturnsEmptyPriceList()
        {
            _mockLoader
                .Setup(f => f.Load(It.IsAny<string>()))
                .Returns(new InventoryDto());

            var service = new StockLoaderService(_mockLoader.Object);

            var stockItems = service.Load("fakePriceList.file");

            stockItems.Count.Should().Be(0);
        }

        [Fact]
        public void Load_ReadValidPriceList_ExtractsPriceListItemsCorrectly()
        {
            _mockLoader
                .Setup(f => f.Load(It.IsAny<string>()))
                .Returns(new InventoryDto
                {
                    Items = new List<InventoryItemDto>(
                        new []
                        {
                            new InventoryItemDto
                            {
                                DispenserId = 3,
                                Quantity = 4,
                                StockKeepingUnit = "RC2L"
                            }
                        })
                });

            var service = new StockLoaderService(_mockLoader.Object);

            var stockItems = service.Load("fakePriceList.file");

            stockItems.Count.Should().Be(1);
            stockItems[0].DispenserId.Should().Be(3);
            stockItems[0].Quantity.Should().Be(4);
            stockItems[0].StockKeepingUnit.Should().Be("RC2L");
        }
    }
}
