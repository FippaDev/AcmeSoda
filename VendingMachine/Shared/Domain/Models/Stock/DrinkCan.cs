using System.Diagnostics.CodeAnalysis;

namespace VendingMachine.Shared.Domain.Models.Stock
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
