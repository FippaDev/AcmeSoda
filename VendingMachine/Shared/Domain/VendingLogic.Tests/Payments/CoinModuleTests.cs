using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Currencies;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using Xunit;

namespace VendingMachine.Shared.Domain.DomainServices.Tests.Payments;

[ExcludeFromCodeCoverage]
public class CoinModuleTests
{
    [Fact]
    public void Constructor_HasZeroBalance()
    {
        var module = new CoinModule();
        Assert.Equal(0.00m, module.AmountDeposited);
    }

    [Fact]
    public void Add_TenPenceCoins_UpdatesBalance()
    {
        bool moneyAddedEventHandlerUsed = false;
        var module = new CoinModule();
        module.MoneyAdded += delegate { moneyAddedEventHandlerUsed = true; };
            
        module.Add(PoundSterling.TenPence);

        Assert.Equal(0.10m, module.AmountDeposited);
        Assert.True(moneyAddedEventHandlerUsed);
    }

    [Fact]
    public void ClearTransaction_ClearsCoinCollection()
    {
        var module = new CoinModule();
        module.Add(PoundSterling.FivePence);
        module.Add(PoundSterling.FiftyPence);

        Assert.Equal(0.55m, module.AmountDeposited);

        module.CancelTransaction();

        Assert.Equal(0.00m, module.AmountDeposited);
    }
}