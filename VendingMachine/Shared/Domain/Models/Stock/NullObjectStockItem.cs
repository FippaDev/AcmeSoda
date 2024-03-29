﻿using System.Diagnostics.CodeAnalysis;

namespace VendingMachine.Shared.Domain.Models.Stock;

/// <summary>
/// This object represents a null or missing object
/// </summary>
[ExcludeFromCodeCoverage]
internal class NullObjectStockItem : StockItem
{
    public NullObjectStockItem() 
        : base("NullObject") 
    {
    }
}