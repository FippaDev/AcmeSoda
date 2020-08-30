using System.Diagnostics.CodeAnalysis;

namespace Models.Stock
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
