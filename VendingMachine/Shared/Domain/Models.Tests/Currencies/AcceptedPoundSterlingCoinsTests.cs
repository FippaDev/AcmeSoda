using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using VendingMachine.Shared.Domain.Models.Currencies;
using Xunit;

namespace VendingMachine.Shared.Domain.Models.Tests.Currencies;

[ExcludeFromCodeCoverage]
public class AcceptedPoundSterlingCoinsTests
{
    [Fact]
    public void AcceptedPoundSterlingCoins_MustHaveAtLeastOneCoin()
    {
        var coins = new AcceptedPoundSterlingCoins();
        coins.Collection().Should().NotBeEmpty();
    }
}