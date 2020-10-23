using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using VendingMachine.Shared.Domain.Domain.Currencies;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainTests.Currencies
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
