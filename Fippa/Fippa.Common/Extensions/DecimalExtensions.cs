namespace Fippa.Common.Extensions
{
    namespace system
    {
        public static class DecimalExtensions
        {
            public static bool GreaterThanZero(this decimal input)
            {
                return input > 0.00m;
            }

            public static bool IsZero(this decimal input)
            {
                return input == 0.00m;
            }
        }
    }
}
