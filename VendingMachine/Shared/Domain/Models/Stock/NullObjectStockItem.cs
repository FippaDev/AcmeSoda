using System.Diagnostics.CodeAnalysis;

namespace Models.Stock
{
    /// <summary>
    /// This object represents a null or missing object
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class NullObjectStockItem : BaseStockItem
    {
        public NullObjectStockItem() 
            : base("NullObject") 
        {
        }
    }
}
