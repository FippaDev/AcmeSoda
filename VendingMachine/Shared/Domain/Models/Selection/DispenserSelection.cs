namespace VendingMachine.Shared.Domain.Models.Selection;

public class DispenserSelection : ISelection
{
    public ushort DispenserId { get; }

    public DispenserSelection(ushort id)
    {
        DispenserId = id;
    }
}