using System.Diagnostics.CodeAnalysis;
using Ardalis.SmartEnum;

namespace VendingMachine.Shared.Domain.Models.Selection;

[ExcludeFromCodeCoverage]
public sealed class SelectionResult : SmartEnum<SelectionResult>
{
    public static readonly SelectionResult InvalidSelection = new SelectionResult(nameof(InvalidSelection), -1);
    public static readonly SelectionResult ValidSelection = new SelectionResult(nameof(ValidSelection), 0);
    public static readonly SelectionResult OutOfStock = new SelectionResult(nameof(OutOfStock), 1);
    public static readonly SelectionResult InsufficientFunds = new SelectionResult(nameof(InsufficientFunds), 2);

    private SelectionResult(string name, int value)
        : base(name, value)
    {
    }
}