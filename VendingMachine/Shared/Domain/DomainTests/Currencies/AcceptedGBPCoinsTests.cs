using System.Diagnostics.CodeAnalysis;
using Domain.Currencies;
using FluentAssertions;
using Xunit;

namespace DomainTests.Currencies
{
    [ExcludeFromCodeCoverage]
    public class AcceptedGBPCoinsTests
    {
        [Fact]
        public void AcceptedGBPCoins_MustHaveAtLeastOneCoin()
        {
            var coins = new AcceptedGBPCoins();
            coins.Collection().Should().NotBeEmpty();
        }
    }
}
