using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public sealed class UnitedStatesDollar : DecimalEnum<UnitedStatesDollar>, ICashPayment
    {
        public static readonly UnitedStatesDollar Cent = new UnitedStatesDollar(nameof(Cent), 0.01m);
        public static readonly UnitedStatesDollar Nickel = new UnitedStatesDollar(nameof(Nickel), 0.05m);
        public static readonly UnitedStatesDollar Dime = new UnitedStatesDollar(nameof(Dime), 0.10M);
        public static readonly UnitedStatesDollar Quarter = new UnitedStatesDollar(nameof(Quarter), 0.25M);
        public static readonly UnitedStatesDollar HalfDollar = new UnitedStatesDollar(nameof(HalfDollar), 0.50M);

        private UnitedStatesDollar(string name, decimal value) 
            : base(name, value)
        {
        }
    }
}
