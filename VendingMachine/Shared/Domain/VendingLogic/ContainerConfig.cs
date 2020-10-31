﻿using System.Diagnostics.CodeAnalysis;
using Fippa.Money.Payments;
using Unity;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.VendingLogic.Admin.Commands;
using VendingMachine.Shared.Domain.VendingLogic.Payments;

namespace VendingMachine.Shared.Domain.VendingLogic
{
    [ExcludeFromCodeCoverage]
    public static class ContainerConfig
    {
        public static void Configure(UnityContainer builder)
        {
            builder.RegisterType<IPaymentModule<ICashPayment>, CoinModule>();
            builder.RegisterType<IVendingMachineLogic, VendingMachineLogic>();
            builder.RegisterType<ICommandController, CommandController>();
            builder.RegisterType<IDispenserModule, SpiralDispenserModule>();
        }
    }
}
