using System.Diagnostics.CodeAnalysis;

namespace Fippa.Common.Enums
{
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
