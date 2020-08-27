using System.Diagnostics.CodeAnalysis;

namespace Fippa.Money
{
    //
    // https://www.planetgeek.ch/2009/07/01/enums-are-evil/
    //
    [ExcludeFromCodeCoverage]
    public abstract class DecimalEnum<TEnum> : Ardalis.SmartEnum.SmartEnum<TEnum, decimal> 
            where TEnum : Ardalis.SmartEnum.SmartEnum<TEnum, decimal>
    {
        protected DecimalEnum(string name, decimal value)
            : base(name, value)
        {
        }
    }
}
