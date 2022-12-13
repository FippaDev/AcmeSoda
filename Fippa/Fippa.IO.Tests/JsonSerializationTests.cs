using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Fippa.IO.Tests;

[ExcludeFromCodeCoverage]
public class JsonSerializationTests
{
    private struct TestSerializableObject
    {
        public string Attribute1 { get; set; }
        public float Attribute2 { get; set; }
        public int Attribute3 { get; set; }
    }

    [Fact]
    public void Save_GivenObject_WritesJsonToStream()
    {
        var toSave =
            new TestSerializableObject
            {
                Attribute1 = "ABC",
                Attribute2 = 3.14f,
                Attribute3 = 42
            };

        var mockStream = new Mock<IStreamWriter>();
        var writer = new JsonSerialization<TestSerializableObject>();
        writer.Save(mockStream.Object, toSave);

        mockStream.Verify(s => s.Write("{\r\n  \"Attribute1\": \"ABC\",\r\n  \"Attribute2\": 3.14,\r\n  \"Attribute3\": 42\r\n}"), Times.Once);
    }

    [Fact]
    public void Load_CallsReadToEnd()
    {
        var mockStream = new Mock<IStreamReader>();
        mockStream.Setup(s => s.ReadToEnd()).Returns("{\r\n  \"Attribute1\": \"ABC\",\r\n  \"Attribute2\": 3.14,\r\n  \"Attribute3\": 42\r\n}");

        var reader = new JsonSerialization<TestSerializableObject>();
        reader.Load(mockStream.Object);

        mockStream.Verify(s => s.ReadToEnd(), Times.Once);
    }

    [Fact]
    public void Load_GivenBadJson_ThrowsException()
    {
        var mockStream = new Mock<IStreamReader>();
        mockStream.Setup(s => s.ReadToEnd()).Returns("{");
        var reader = new JsonSerialization<TestSerializableObject>();

        Assert.Throws<JsonSerializationException>(() =>
        {
            reader.Load(mockStream.Object);
        });
    }
}