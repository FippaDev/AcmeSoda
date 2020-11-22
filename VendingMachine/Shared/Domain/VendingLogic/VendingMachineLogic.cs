using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.Models.Selection;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        private readonly IPaymentModule<ICashPayment> _coinModule;
        private decimal _balance;

        private readonly IDispenserModule _dispenserModule;

        private readonly List<PaymentCommand> _deposits = new List<PaymentCommand>();
        private readonly List<ProductCommand> _purchases = new List<ProductCommand>();

        public PriceList PriceList { get; set; }
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
            IPaymentModule<ICashPayment> coinModule)
        {
            _dispenserModule = dispenserModule;
            _coinModule = coinModule;
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

        public SelectionResult MakeSelection(string input)
        {
            var result = _dispenserModule.GetDispenser(input);
            var selectionResult = result.Item1;
            var dispenser = result.Item2;

            if (selectionResult == SelectionResult.ValidSelection)
            {
                var rrp = PriceList.LookupByStockKeepingUnit(dispenser.StockItem.StockKeepingUnit);
                _purchases.Add(new ProductCommand(dispenser.StockItem, rrp));
            }

            return selectionResult;
        }

        public string GetStockReport()
        {
            return _dispenserModule.GetStockReport();
        }
    }
}
