using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace Fippa.Money.Tests.Change
{
    internal static class CashFloatSetup
    {
        private static CashFloat<GBPCoins> EmptyFloat()
        {
            var cashFloat = new CashFloat<GBPCoins>(50);
            cashFloat.AddCoins(GBP.OnePenny, 0);
            cashFloat.AddCoins(GBP.TwentyPence, 0);
            cashFloat.AddCoins(GBP.FivePence, 0);
            cashFloat.AddCoins(GBP.TenPence, 0);
            cashFloat.AddCoins(GBP.TwentyPence, 0);
            cashFloat.AddCoins(GBP.FiftyPence, 0);
            cashFloat.AddCoins(GBP.OnePound, 0);
            cashFloat.AddCoins(GBP.TwoPound, 0);
            return cashFloat;
        }

        public static CashFloat<GBPCoins> SmallFloat()
        {
            var cashFloat = new CashFloat<GBPCoins>(50);
            cashFloat.AddCoins(GBP.OnePenny, 0);
            cashFloat.AddCoins(GBP.TwentyPence, 0);
            cashFloat.AddCoins(GBP.FivePence, 10);
            cashFloat.AddCoins(GBP.TenPence, 10);
            cashFloat.AddCoins(GBP.TwentyPence, 10);
            cashFloat.AddCoins(GBP.FiftyPence, 10);
            cashFloat.AddCoins(GBP.OnePound, 10);
            cashFloat.AddCoins(GBP.TwoPound, 10);
            return cashFloat;
        }
    }
}
