using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    [ExcludeFromCodeCoverage]
    public class NotSupportedPayment : ICashPayment
    {
        public decimal Value { get; } = 0.00m;
    }
}
