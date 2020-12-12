using System;
using System.Collections.Generic;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Commands;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.DomainServices
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        PriceList PriceList { get; set; }
        EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        void AddPayment(IPaymentCommand command);
        void AddProduct(IProductCommand command);

        SelectionResult MakeSelection(string input);
        void LoadInventory(IEnumerable<InventoryItem> items);
        IEnumerable<StockReportLine> GetStockReport();
    }
}