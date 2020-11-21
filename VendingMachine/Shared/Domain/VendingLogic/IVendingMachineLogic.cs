﻿using System;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public interface IVendingMachineLogic
    {
        decimal Balance { get; }
        EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        void AddPayment(PaymentCommand command);
        void AddProduct(ProductCommand command);

        SelectionResult MakeSelection(string input);
    }
}