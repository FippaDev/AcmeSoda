using Ardalis.SmartEnum;
using Fippa.Money.Payments;

namespace Fippa.Money.Currencies
{
    public static class CurrencyParser<T> where T : SmartEnum<T, decimal>, ICashPayment
    {
        public static ICashPayment Parse(string valueString)
        {
            if (decimal.TryParse(valueString, out var value)
                &&
                SmartEnum<T, decimal>.TryFromValue(value, out var coin))
            {
                return coin;
            }

            return new NotSupportedPayment();
        }
    }
}
