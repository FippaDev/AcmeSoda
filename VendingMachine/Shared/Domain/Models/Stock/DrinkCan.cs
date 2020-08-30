using System.Diagnostics.CodeAnalysis;

namespace Models.Stock
{
    [ExcludeFromCodeCoverage]
    internal class DrinkCan : BaseStockItem
    {
        public DrinkCan(string stockKeepingUnit) 
            : base(stockKeepingUnit)
        {
        }
    }
}
