using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Fippa.IO.Tests
{
    [ExcludeFromCodeCoverage]
    public class JsonSerializationTests
    {
        private struct GroupOfValues
        {
            public string StringValue { get; set; }
            public float FloatValue { get; set; }
            public int IntValue { get; set; }
        }

        [Fact]
        public void Save_GivenObject_WritesJsonToStream()
        {
            var toSave =
                new GroupOfValues
                {
                    StringValue = "ABC",
                    FloatValue = 3.14f,
                    IntValue = 42
                };

            var mockStream = new Mock<IStreamWriter>();
            var writer = new JsonSerialization<GroupOfValues>();
            writer.Save(mockStream.Object, toSave);

            mockStream.Verify(s => s.Write("{\r\n  \"StringValue\": \"ABC\",\r\n  \"FloatValue\": 3.14,\r\n  \"IntValue\": 42\r\n}"), Times.Once);
        }

        [Fact]
        public void Load_CallsReadToEnd()
        {
            var mockStream = new Mock<IStreamReader>();
            var reader = new JsonSerialization<GroupOfValues>();
            reader.Load(mockStream.Object);

            mockStream.Verify(s => s.ReadToEnd(), Times.Once);
        }

        [Fact]
        public void Load_GivenBadJson_ThrowsException()
        {
            var mockStream = new Mock<IStreamReader>();
            mockStream.Setup(s => s.ReadToEnd()).Returns("{");
            var reader = new JsonSerialization<GroupOfValues>();

            Assert.Throws<JsonSerializationException>(() =>
            {
                reader.Load(mockStream.Object);
            });
        }
    }
}