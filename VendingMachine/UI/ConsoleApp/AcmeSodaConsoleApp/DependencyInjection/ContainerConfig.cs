using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Console;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Fippa.Money.Payments;
using Infrastructure;
using Unity;
using Unity.Lifetime;
using UserInterface;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Domain.VendingLogic;
using VendingMachine.Shared.Domain.VendingLogic.Payments;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public sealed class ContainerConfig
    {
        public static void Configure(IUnityContainer container)
        {
            //container.RegisterType<IDependencyInjectionContainer, DependencyInjectionContainer>(TypeLifetime.Singleton);
            container.RegisterType<IConsoleApplication, ConsoleApplication>();
            container.RegisterType<IConsole, CommandLineConsole>();
            container.RegisterType<IUserInput, ConsoleKeypad>();
            container.RegisterType<IUserOutput, ConsoleOutput>();

            ConfigureSharedDomainModels(container);
            ConfigureSharedServices(container);
            ConfigureSharedInfrastructure(container);
        }

        private static void ConfigureSharedDomainModels(IUnityContainer container)
        {
            container.RegisterType<IDispenserModule, SpiralDispenserModule>();

            container.RegisterType<IPaymentModule<ICashPayment>, CoinModule>();
            container.RegisterType<IVendingMachineLogic, VendingMachineLogic>();

            container.RegisterSingleton<IPriceListService, PriceListService>();
        }

        private static void ConfigureSharedServices(IUnityContainer container)
        {
            container.RegisterType<IVendingMachineFactory, VendingMachineFactory>();
            container.RegisterType<IVendingMachine, VendingMachine.Shared.Services.VendingMachine>();
            container.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
        }

        private static void ConfigureSharedInfrastructure(IUnityContainer container)
        {
            container.RegisterType<IStreamReader, StreamReaderWrapper>();
            container.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
            container.RegisterType(typeof(IDataLoader<>), typeof(DataLoader<>), new TransientLifetimeManager());
        }
    }
}