using BusinessLogic.Payments;
using Fippa.Money.Payments;
using Unity;

namespace BusinessLogic
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
