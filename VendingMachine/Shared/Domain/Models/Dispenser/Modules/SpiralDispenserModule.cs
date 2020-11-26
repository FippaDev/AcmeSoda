using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;

[assembly:InternalsVisibleTo("VendingMachine.Shared.Domain.Models.Tests")]
namespace VendingMachine.Shared.Domain.Models.Dispenser.Modules
{
    public class SpiralDispenserModule : AbstractDispenserModule
    {
        public SpiralDispenserModule(ISelectionStrategy selectionStrategy)
            : base(selectionStrategy)
        {
        }

        public override void Initialise(ushort[] dimensions)
        {
            ushort rows = dimensions[0];
            ushort columns = dimensions[1];
            ushort depth = dimensions[2];

            Guard.Against.Zero(rows, nameof(rows));
            Guard.Against.Zero(columns, nameof(columns));
            Guard.Against.Zero(depth, nameof(depth));

            for (ushort id = 0; id < rows * columns; id++)
            {
                _holders.Add(new Dispenser(id, depth));
            }
        }
    }
}
