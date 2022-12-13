using System;
using System.Runtime.Serialization;
using Fippa.IO.Streams;
using Moq;
using Xunit;

namespace Infrastructure.Tests;

public class DataLoaderTests
{
    [Fact]
    public void Constructor_WhenStreamIsNull_ThrowsException()
    {
        var serializer = new Mock<Fippa.IO.Serialization.IObjectSerializer<ISerializable>>();
        Assert.Throws<ArgumentNullException>(() =>
        {
            var dataLoader = new DataLoader<ISerializable>(null, serializer.Object);
        });
    }

    [Fact]
    public void Constructor_WhenSerializerIsNull_ThrowsException()
    {
        var streamReader = new Mock<IStreamReader>();
        Assert.Throws<ArgumentNullException>(() =>
        {
            var dataLoader = new DataLoader<ISerializable>(streamReader.Object, null);
        });
    }

    [Fact]
    public void Load_CallsSerializerLoad()
    {
        var streamReader = new Mock<IStreamReader>();
        var serializer = new Mock<Fippa.IO.Serialization.IObjectSerializer<ISerializable>>();
        var dataLoader = new DataLoader<ISerializable>(streamReader.Object, serializer.Object);

        dataLoader.Load(@"c:\temp\fake.txt");

        serializer.Verify(s => s.Load(It.IsAny<IStreamReader>()), Times.Once);
    }

    [Fact]
    public void Dispose_DisposesStreamButNotSerializer()
    {
        var streamReader = new Mock<IStreamReader>();
        var serializer = new Mock<Fippa.IO.Serialization.IObjectSerializer<ISerializable>>();
        var dataLoader = new DataLoader<ISerializable>(streamReader.Object, serializer.Object);

        dataLoader.Dispose();

        streamReader.Verify(s => s.Dispose(), Times.Once);
    }
}