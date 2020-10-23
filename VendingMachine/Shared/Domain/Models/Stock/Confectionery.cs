using System.Diagnostics.CodeAnalysis;

namespace VendingMachine.Shared.Domain.Models.Stock
{
    [ExcludeFromCodeCoverage]
    internal class Confectionery : BaseStockItem
    {
        public Confectionery(string stockKeepingUnit) 
            : base(stockKeepingUnit)
        {
        }
    }
}
