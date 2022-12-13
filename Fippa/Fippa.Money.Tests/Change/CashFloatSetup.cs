using Fippa.Money.Currencies;
using Fippa.Money.Payments;

namespace Fippa.Money.Tests.Change
{
    internal static class CashFloatSetup
    {
        private static CashFloat<PoundSterlingCoins> EmptyFloat()
        {
            var cashFloat = new CashFloat<PoundSterlingCoins>(50);
            cashFloat.AddCoins(PoundSterling.OnePenny, 0);
            cashFloat.AddCoins(PoundSterling.TwentyPence, 0);
            cashFloat.AddCoins(PoundSterling.FivePence, 0);
            cashFloat.AddCoins(PoundSterling.TenPence, 0);
            cashFloat.AddCoins(PoundSterling.TwentyPence, 0);
            cashFloat.AddCoins(PoundSterling.FiftyPence, 0);
            cashFloat.AddCoins(PoundSterling.OnePound, 0);
            cashFloat.AddCoins(PoundSterling.TwoPound, 0);
            return cashFloat;
        }

        public static CashFloat<PoundSterlingCoins> SmallFloat()
        {
            var cashFloat = new CashFloat<PoundSterlingCoins>(50);
            cashFloat.AddCoins(PoundSterling.OnePenny, 0);
            cashFloat.AddCoins(PoundSterling.TwentyPence, 0);
            cashFloat.AddCoins(PoundSterling.FivePence, 10);
            cashFloat.AddCoins(PoundSterling.TenPence, 10);
            cashFloat.AddCoins(PoundSterling.TwentyPence, 10);
            cashFloat.AddCoins(PoundSterling.FiftyPence, 10);
            cashFloat.AddCoins(PoundSterling.OnePound, 10);
            cashFloat.AddCoins(PoundSterling.TwoPound, 10);
            return cashFloat;
        }
    }
}
