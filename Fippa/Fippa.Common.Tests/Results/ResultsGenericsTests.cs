using System;
using Fippa.Common.Results;
using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results
{
    public class ResultsGenericsTests
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
        public void Success_DoesNotThrowAnyException()
        {
            var result = Result.Success<string>("testValue");

            result.Should().NotBe(null);
            result.Error.Should().Be(null);

            result.Successful.Should().Be(true);
            result.Value.Should().Be("testValue");
        }

        [Fact]
        public void Fail_TestError_DoesNotThrowAnyException()
        {
            var result = Result.Fail(new TestError<string>("Something went wrong"));
            result.Should().NotBe(null);
            result.Error.Should().BeOfType(typeof(TestError<string>));
            ((TestError<string>)result.Error).Value.Should().Be("Something went wrong");

            result.Successful.Should().Be(false);
        }

        [Fact]
        public void Fail_WithNull_ThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Result.Fail(null);
            });
        }
    }
}
