using System;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

[assembly: InternalsVisibleTo("VendingMachine.Shared.Services.Tests")]
namespace VendingMachine.Shared.Services
{
    public class VendingMachine : IVendingMachine
    {
        private readonly IVendingMachineLogic _logic;
        private readonly IUserOutput _output;

        public string Manufacturer { get; }
 
        public VendingMachine(
            IUserOutput output,
            IVendingMachineLogic logic,
            string manufacturer)
        {
            _output = output;
            _logic = logic;

            Guard.Against.NullOrEmpty(manufacturer, nameof(manufacturer));
            Manufacturer = manufacturer;

            _logic.BalanceChanged += OnBalanceChanged;
        }

        private void OnBalanceChanged(object sender, BalanceChangedEvent e)
        {
            _output.ShowBalance(_logic.Balance);
        }

        public SelectionResult MakeSelection(Selection selection)
        {
            return _logic.MakeSelection(selection);
        }

        public void Initialise()
        {
            _output.ShowWelcomeMessage(Manufacturer);
        }

        public void AddPayment(PaymentCommand command)
        {
            _logic.AddPayment(command);
        }

        public void AddProduct(ProductCommand command)
        {
            _logic.AddProduct(command);
        }

        /// <summary>
        /// Check that the selection code is valid and whether there is a product at that location.
        /// </summary>
        /// <param name="selectionCode"></param>
        /// <returns></returns>
        public Tuple<SelectionResult, Selection> ValidateSelection(string selectionCode)
        {
            return new Tuple<SelectionResult, Selection>(
                SelectionResult.InvalidSelection,
                new Selection(null, null, 0.00m));
        }
    }
}