﻿using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Commands;

namespace VendingMachine.Shared.Domain.Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void Initialise();
        void AddPayment(PaymentCommand command);
        void AddProduct(ProductCommand command);

        SelectionResult MakeSelection(string input);
        void ShowStockLevels();
        void LoadPriceList(string filename);
        void LoadStock(string filename);
    }
}
