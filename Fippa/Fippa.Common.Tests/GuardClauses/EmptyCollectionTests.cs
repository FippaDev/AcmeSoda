using System;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;
using Xunit;

namespace Fippa.Common.Tests.GuardClauses
{
    [ExcludeFromCodeCoverage]
    public class EmptyCollectionTests
    {
        [Fact]
        public void EmptyCollection_IfInputIsNull_ThrowsException()
        {
            int[] collection = null;
            Assert.Throws<ArgumentNullException>(() =>
                Guard.Against.EmptyCollection(collection, string.Empty));
        }

        [Fact]
        public void EmptyCollection_IfInputIsAnEmptyCollection_ThrowsException()
        {
            int[] collection = new int[0];
            Assert.Throws<ArgumentException>(() =>
                Guard.Against.EmptyCollection(collection, string.Empty));
        }

        [Fact]
        public void EmptyCollection_IfInputIsNotEmpty_DoesNothing()
        {
            int[] collection = new int[1] {33};
            Guard.Against.EmptyCollection(collection, string.Empty);
        }
    }
}
