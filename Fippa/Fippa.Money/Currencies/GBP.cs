using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public sealed class GBP : DecimalEnum<GBP>, ICashPayment
    {
        public static readonly GBP OnePenny = new GBP(nameof(OnePenny), 0.01m);
        public static readonly GBP TwoPence = new GBP(nameof(TwoPence), 0.02m);
        public static readonly GBP FivePence = new GBP(nameof(FivePence), 0.05m);
        public static readonly GBP TenPence = new GBP(nameof(TenPence), 0.10m);
        public static readonly GBP TwentyPence = new GBP(nameof(TwentyPence), 0.20M);
        public static readonly GBP FiftyPence = new GBP(nameof(FiftyPence), 0.50M);
        public static readonly GBP OnePound = new GBP(nameof(OnePound), 1.00M);
        public static readonly GBP TwoPound = new GBP(nameof(TwoPound), 2.00M);

        private GBP(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
