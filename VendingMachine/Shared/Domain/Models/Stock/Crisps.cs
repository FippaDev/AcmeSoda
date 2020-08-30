using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;

namespace Models.Stock
{
    [ExcludeFromCodeCoverage]
    internal class Crisps : BaseStockItem
    {
        public Crisps(string stockKeepingUnit) 
            : base(stockKeepingUnit)
        {
            Guard.Against.Null(stockKeepingUnit, nameof(stockKeepingUnit));
        }
    }
}
