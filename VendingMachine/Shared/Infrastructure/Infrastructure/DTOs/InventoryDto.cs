using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.DTOs;

[Serializable, ExcludeFromCodeCoverage]
public class InventoryDto
{
    public List<InventoryItemDto> Items { get; set; } = new List<InventoryItemDto>();
}