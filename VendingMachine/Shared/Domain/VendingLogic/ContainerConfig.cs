using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;
using Models;
using Unity;
using VendingLogic.Admin;
using VendingLogic.Admin.Commands;
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
            builder.RegisterType<IAdminModule, AdminModule>();
            builder.RegisterType<IAuthenticationModule, AuthenticationModule>();
            builder.RegisterType<ICommandController, CommandController>();
            builder.RegisterType<IDispenserModule, SpiralDispenserModule>();
        }
    }
}
