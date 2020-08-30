using System;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Fippa.Money.Payments;
using Models.Pricing;
using VendingLogic;
using VendingLogic.Admin;
using VendingLogic.Payments;
using VendingLogic.Selection;

[assembly: InternalsVisibleTo("Services.Tests")]
namespace Services
{
    internal class VendingMachine : IVendingMachine
    {
        private readonly IVendingMachineLogic _vendingMachine;
        private readonly IObjectSerializer<PriceList> _objectSerializer;
        private readonly IAdminModule _adminModule;

        public decimal Balance => _vendingMachine.Balance;

        public EventHandler<BalanceChangedEvent>? BalanceChanged { get; set; }
        public EventHandler<ItemDispensedNotificationEvent>? ItemDispensed { get; set; }

        public string Manufacturer { get; }
 
        public VendingMachine(
            IObjectSerializer<PriceList> objectSerializer,
            IVendingMachineLogic vendingMachine,
            IAdminModule adminModule,
            string manufacturer)
        {
            _objectSerializer = objectSerializer;
            _vendingMachine = vendingMachine;
            _adminModule = adminModule;
            Guard.Against.NullOrEmpty(manufacturer, nameof(manufacturer));
            Manufacturer = manufacturer;

            _vendingMachine.BalanceChanged += OnBalanceChanged;
            _vendingMachine.ItemDispensed += OnItemDispensed;
        }

        public void AddPayment(IPayment payment)
        {
            _vendingMachine.AddPayment(payment);
        }

        private void OnBalanceChanged(object sender, BalanceChangedEvent e)
        {
            BalanceChanged?.Invoke(this, e);
        }

        public SelectionResult MakeSelection(ushort selectionCode)
        {
            return _vendingMachine.MakeSelection(selectionCode);
        }

        internal void LoadPriceList(string filename)
        {
            using var reader = new StreamReaderWrapper(filename);
            var priceList = _objectSerializer.Load(reader);
            _vendingMachine.UpdatePriceList(priceList);
        }

        private void OnItemDispensed(object sender, ItemDispensedNotificationEvent e)
        {
            ItemDispensed?.Invoke(this, e);
        }
    }
}