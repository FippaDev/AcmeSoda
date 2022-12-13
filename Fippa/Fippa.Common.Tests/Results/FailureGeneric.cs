using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results
{
    public class FailureGeneric
    {
        private class TestError<T> : IError<T>
        {
            public T Value { get; }

            public TestError(T value)
            {
                Value = value;
            }
        }

        [Fact]
        public void Constructor_WithAnError_DoesNotThrowAnyException()
        {
            var result = new Fippa.Common.Results.Failure(new TestError<string>("Something went wrong"));

            result.Error.Should().BeOfType(typeof(TestError<string>));
            ((TestError<string>)result.Error).Value.Should().Be("Something went wrong");

            result.Successful.Should().Be(false);
        }
    }
}
