using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Fippa.Money.Payments;
using Infrastructure;
using Infrastructure.DTOs;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models.Pricing;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Admin;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

[assembly: InternalsVisibleTo("VendingMachine.Shared.Services.Tests")]
namespace VendingMachine.Shared.Services
{
    internal class VendingMachine : IVendingMachine
    {
        private readonly IVendingMachineLogic _vendingMachine;
        private readonly IUserOutput _output;
        private readonly IDataLoader<PriceListDto> _dataLoader;
        private readonly IAdminModule _adminModule;

        public EventHandler<ItemDispensedNotificationEvent>? ItemDispensed { get; set; }

        public string Manufacturer { get; }
 
        public VendingMachine(
            IUserOutput output,
            IDataLoader<PriceListDto> dataLoader,
            IVendingMachineLogic vendingMachine,
            IAdminModule adminModule,
            string manufacturer)
        {
            _output = output;
            _dataLoader = dataLoader;
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
            _output.ShowBalance(_vendingMachine.Balance);
        }

        public SelectionResult MakeSelection(ushort selectionCode)
        {
            return _vendingMachine.MakeSelection(selectionCode);
        }

        public void ShowBalance()
        {
            _output.ShowBalance(_vendingMachine.Balance);
        }

        public void AcknowledgeCoinInserted(ICashPayment coin)
        {
            _output.Message($"{coin.Value} inserted");
        }

        internal void LoadPriceList(string filename)
        {
            //using var reader = new StreamReaderWrapper(filename);
            //var priceList = _dataLoader.Load(reader);
            //_vendingMachine.UpdatePriceList(priceList);
            
            var dto = _dataLoader.Load(filename);

            var items = new List<PriceListStockItem>();
            foreach (var item in dto.Items)
            {
                items.Add(
                    new PriceListStockItem(
                    item.Key, 
                    item.Value.DisplayName, 
                    item.Value.RetailPrice));
            }

            var priceList = new PriceList(items);

            _vendingMachine.UpdatePriceList(priceList);
        }

        private void OnItemDispensed(object sender, ItemDispensedNotificationEvent e)
        {
            ItemDispensed?.Invoke(this, e);
        }
    }
}