﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models.Dispenser;

public interface IDispenserModule
{
    StockItem Dispense(string input);
    Tuple<SelectionResult, IDispenser> GetDispenser(string input);
    bool IsEmpty { get; }
    void Load(IEnumerable<InventoryItem> items);
    ReadOnlyCollection<StockReportLine> GetStockReport(IStockReporting reportGenerator, PriceList priceList);
}