using System.Collections.Generic;
using FluentAssertions;
using Infrastructure;
using Infrastructure.DTOs;
using Moq;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainServices.Tests;

public class PriceListServiceTests
{
    private readonly Mock<IDataLoader<PriceListDto>> _mockLoader = new Mock<IDataLoader<PriceListDto>>();

    [Fact]
    public void Load_ReadFromEmptyFile_ReturnsEmptyPriceList()
    {
        _mockLoader
            .Setup(f => f.Load(It.IsAny<string>()))
            .Returns(new PriceListDto());

        var service = new PriceListService(_mockLoader.Object);

        var priceList = service.Load("fakePriceList.file");

        priceList.Items.Count.Should().Be(0);
    }

    [Fact]
    public void Load_ReadValidPriceList_ExtractsPriceListItemsCorrectly()
    {
        _mockLoader
            .Setup(f => f.Load(It.IsAny<string>()))
            .Returns(new PriceListDto
            {
                Items = new List<PriceListStockItemDto>(
                    new []
                    {
                        new PriceListStockItemDto
                        {
                            DisplayName = "Cola",
                            RetailPrice = 0.19m,
                            StockKeepingUnit = "RC2L"
                        }
                    })
            });

        var service = new PriceListService(_mockLoader.Object);

        var priceList = service.Load("fakePriceList.file");

        priceList.Items.Count.Should().Be(1);
        priceList.Items[0].DisplayName.Should().Be("Cola");
        priceList.Items[0].RetailPrice.Should().Be(0.19m);
        priceList.Items[0].StockKeepingUnit.Should().Be("RC2L");
    }
}