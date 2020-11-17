﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private readonly IPriceListService _priceListService;
        private decimal _balance;

        private readonly IDispenserModule _dispenserModule;

        private List<PaymentCommand> _deposits = new List<PaymentCommand>();
        private List<ProductCommand> _purchases = new List<ProductCommand>();

        public EventHandler<BalanceChangedEvent> BalanceChanged { get; set; }

        public decimal Balance
        {
            get => _balance;

            private set
            {
                _balance = value;
                BalanceChanged?.Invoke(this, new BalanceChangedEvent(_balance));
            }
        }

        public VendingMachineLogic(
            IDispenserModule dispenserModule,
            IPaymentModule<ICashPayment> coinModule,
            IPriceListService priceListService)
        {
            _dispenserModule = dispenserModule;
            _coinModule = coinModule;
            _priceListService = priceListService;
            _coinModule.MoneyAdded += OnMoneyAdded;
        }

        private void OnMoneyAdded(object sender, MoneyAddedEvent e)
        {
            Balance += e.Amount;
        }

        public void AddPayment(IPayment payment)
        {
            Guard.Against.Null(payment, nameof(payment));
            var cashPayment = payment as ICashPayment;

            if (cashPayment == null)
            {
                throw new ArgumentException("Only cash payments are accepted. There is no card module");
            }

            _coinModule.Add(cashPayment);
        }

        public void CancelTransaction()
        {
            _coinModule.CancelTransaction();
            Balance = 0.00m;
        }

        public void AddPayment(PaymentCommand command)
        {
            _deposits.Add(command);
            Balance += command.Value;

            if (Balance > _purchases.Sum(c => c.Value))
            {
                // TODO: Make automatic purchase
            }
        }

        public void AddProduct(ProductCommand command)
        {
            _purchases.Add(command);
            Balance -= command.Value;
        }

        public Tuple<SelectionResult, BaseStockItem> FindStockItem(ISelection selection)
        {
            return _dispenserModule.FindStockItem(selection);
        }
    }
}
