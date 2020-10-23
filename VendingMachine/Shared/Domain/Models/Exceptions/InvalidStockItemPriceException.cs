using System;
using System.Diagnostics.CodeAnalysis;

namespace VendingMachine.Shared.Domain.Models.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidStockItemPriceException : Exception
    {
        public InvalidStockItemPriceException(string message)
            : base(message)
        {
        }
    }
}
