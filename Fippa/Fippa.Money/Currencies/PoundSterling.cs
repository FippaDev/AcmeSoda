using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public sealed class PoundSterling : DecimalEnum<PoundSterling>, ICashPayment
    {
        public static readonly PoundSterling OnePenny = new PoundSterling(nameof(OnePenny), 0.01m);
        public static readonly PoundSterling TwoPence = new PoundSterling(nameof(TwoPence), 0.02m);
        public static readonly PoundSterling FivePence = new PoundSterling(nameof(FivePence), 0.05m);
        public static readonly PoundSterling TenPence = new PoundSterling(nameof(TenPence), 0.10m);
        public static readonly PoundSterling TwentyPence = new PoundSterling(nameof(TwentyPence), 0.20M);
        public static readonly PoundSterling FiftyPence = new PoundSterling(nameof(FiftyPence), 0.50M);
        public static readonly PoundSterling OnePound = new PoundSterling(nameof(OnePound), 1.00M);
        public static readonly PoundSterling TwoPound = new PoundSterling(nameof(TwoPound), 2.00M);

        private PoundSterling(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
