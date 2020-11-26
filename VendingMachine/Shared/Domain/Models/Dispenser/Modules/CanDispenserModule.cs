using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules
{
    public class CanDispenserModule : AbstractDispenserModule
    {
        public CanDispenserModule(ISelectionStrategy selectionStrategy)
            : base(selectionStrategy)
        {
        }

        public override void Initialise(ushort[] dimensions)
        {
            ushort numberOfHolders = dimensions[0];
            ushort capacityPerHolder = dimensions[1];

            Guard.Against.Zero(numberOfHolders, nameof(numberOfHolders));
            Guard.Against.Zero(capacityPerHolder, nameof(capacityPerHolder));

            for (ushort id = 0; id < numberOfHolders; id++)
            {
                _holders.Add(new Dispenser(id++, capacityPerHolder));
            }
        }
    }
}
