using VendingLogic.Payments;
using Xunit;

namespace VendingLogic.Tests.Payments
{ 
    public class MoneyAddedEventTests
    {
        [Fact]
        public void MoneyAddedEventTests_GivenItem_SetsProperty()
        {
            var amount = 0.79m;

            var moneyAddedEvent = new MoneyAddedEvent(amount);

            Assert.Equal(amount, moneyAddedEvent.Amount);
        }
    }
}
