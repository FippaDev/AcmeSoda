using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public sealed class USD : DecimalEnum<USD>, ICashPayment
    {
        public static readonly USD Cent = new USD(nameof(Cent), 0.01m);
        public static readonly USD Nickel = new USD(nameof(Nickel), 0.05m);
        public static readonly USD Dime = new USD(nameof(Dime), 0.10M);
        public static readonly USD Quarter = new USD(nameof(Quarter), 0.25M);
        public static readonly USD HalfDollar = new USD(nameof(HalfDollar), 0.50M);

        private USD(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
