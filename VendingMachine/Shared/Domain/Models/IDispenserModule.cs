using VendingMachine.Shared.Domain.Models.Stock;

namespace VendingMachine.Shared.Domain.Models
{
    public interface IDispenserModule
    {
        ushort MinSelectionCode { get; }
        ushort MaxSelectionCode { get; }

        bool IsValidSelectionCode(ushort selectionCode);
        string GetStockKeepingUnitCode(ushort selectionCode);

        BaseStockItem Dispense(byte identifier);
    }
}