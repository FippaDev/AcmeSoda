namespace Fippa.Common.Extensions
{
    namespace system
    {
        public static class HasValueExtension
        {
            public static bool HasValue(this string? input)
            {
                return input != null && !string.IsNullOrWhiteSpace(input);
            }
        }
    }
}
