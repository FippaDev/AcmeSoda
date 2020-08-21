using System;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses
{
    [ExcludeFromCodeCoverage]
    public class TypeCheckTests
    {
        [Fact]
        public void TypeChecking_IfNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                Guard.Against.TypeChecking(null, typeof(int)));
        }

        [Fact]
        public void TypeChecking_IfDifferentType_ThrowsException()
        {
            float x = 1.0f;
            Assert.Throws<ArgumentException>(() =>
                Guard.Against.TypeChecking(x.GetType(), typeof(int)));
        }

        [Fact]
        public void TypeChecking_WhenSameType_DoesNotAssert()
        {
            float x = 1.0f;
            Guard.Against.TypeChecking(x.GetType(), typeof(float));
        }
    }
}
