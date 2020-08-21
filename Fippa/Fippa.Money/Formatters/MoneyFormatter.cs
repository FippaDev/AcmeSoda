namespace Fippa.Money.Formatters
{
    public static class MoneyFormatter
    {
        public static string DisplayAsCurrency(this decimal balance)
        {
            return $"{balance:C}";
        }
    }
}
