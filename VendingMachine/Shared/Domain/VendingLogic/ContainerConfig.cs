using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;
using Unity;
using VendingLogic.Payments;

namespace VendingLogic
{
    [ExcludeFromCodeCoverage]
    public static class ContainerConfig
    {
        public static void Configure(UnityContainer builder)
        {
            builder.RegisterType<IPaymentModule<ICashPayment>, CoinModule>();
            builder.RegisterType<IVendingMachineLogic, VendingMachineLogic>();
        }
    }
}
