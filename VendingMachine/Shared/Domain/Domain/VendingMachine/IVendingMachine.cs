using System;
using VendingMachine.Shared.Domain.VendingLogic.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Selection;

namespace VendingMachine.Shared.Domain.Domain.VendingMachine
{
    public interface IVendingMachine
    {
        string Manufacturer { get; }

        void Initialise(string priceListFile);
        void AddCommand(VendingLogic.Commands.Command command);
        Tuple<ProductCommand,SelectionResult> IdentifyProductBySelectionCode(string selectionCode);
    }
}
