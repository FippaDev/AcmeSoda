using Fippa.Money.Payments;

namespace Fippa.Money.Currencies.GBP
{
    public sealed class Coin : DecimalEnum<Coin>, ICashPayment
    {
        public static readonly Coin InvalidCoin = new Coin("Invalid", 0.00m);

        public static readonly Coin OnePenny = new Coin(nameof(OnePenny), 0.01m);
        public static readonly Coin TwoPence = new Coin(nameof(TwoPence), 0.02m);
        public static readonly Coin FivePence = new Coin(nameof(FivePence), 0.05m);
        public static readonly Coin TenPence = new Coin(nameof(TenPence), 0.10m);
        public static readonly Coin TwentyPence = new Coin(nameof(TwentyPence), 0.20M);
        public static readonly Coin FiftyPence = new Coin(nameof(FiftyPence), 0.50M);
        public static readonly Coin OnePound = new Coin(nameof(OnePound), 1.00M);
        public static readonly Coin TwoPound = new Coin(nameof(TwoPound), 2.00M);

        private Coin(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
