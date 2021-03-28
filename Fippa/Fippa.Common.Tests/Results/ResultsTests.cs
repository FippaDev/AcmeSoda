using System;
using Fippa.Common.Results;
using FluentAssertions;
using Xunit;

namespace Fippa.Common.Tests.Results
{
    public class ResultsTests
    {
        private class TestError : IError
        {
        }

        [Fact]
        public void Success_DoesNotThrowAnyException()
        {
            var result = Result.Success();

            result.Should().NotBe(null);
            result.Error.Should().Be(null);

            result.Successful.Should().Be(true);
        }

        [Fact]
        public void Fail_WithIError_DoesNotThrowAnyException()
        {
            var result = Result.Fail(new TestError());

            result.Should().NotBe(null);
            result.Error.Should().BeOfType(typeof(TestError));

            result.Successful.Should().Be(false);
        }

        [Fact]
        public void Fail_WithNull_ThrowsAnException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Result.Fail(null);
            });
        }
    }
}
