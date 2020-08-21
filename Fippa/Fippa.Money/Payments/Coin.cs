using Fippa.Common.Enums;

namespace Fippa.Money.Payments
{
    public sealed class Coin : DecimalEnum<Coin>, IPayment
    {
        public static readonly Coin InvalidCoin = new Coin("Invalid", 0.00m);

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

        public static Coin Parse(string valueString)
        {
            if (decimal.TryParse(valueString, out var value) 
                &&
                Coin.TryFromValue(value, out var coin))
            {
                return coin;
            }

            return InvalidCoin;
        }
    }
}
