using Fippa.Money.Payments;

namespace Fippa.Money.Currencies.USD
{
    public sealed class Coin : DecimalEnum<Coin>, ICashPayment
    {
        public static readonly Coin InvalidCoin = new Coin("Invalid", 0.00m);

        public static readonly Coin Cent = new Coin(nameof(Cent), 0.01m);
        public static readonly Coin Nickel = new Coin(nameof(Nickel), 0.05m);
        public static readonly Coin Dime = new Coin(nameof(Dime), 0.10M);
        public static readonly Coin Quarter = new Coin(nameof(Quarter), 0.25M);
        public static readonly Coin HalfDollar = new Coin(nameof(HalfDollar), 0.50M);

        private Coin(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
