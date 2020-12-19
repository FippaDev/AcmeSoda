using System.Diagnostics.CodeAnalysis;
using AcmeSodaConsoleApp.StockReport;
using Fippa.IO.Console;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Fippa.Money.Payments;
using Infrastructure;
using Unity;
using Unity.Lifetime;
using UserInterface;
using VendingMachine.Shared.Domain.DomainServices;
using VendingMachine.Shared.Domain.DomainServices.Payments;
using VendingMachine.Shared.Domain.Models.Dispenser;
using VendingMachine.Shared.Domain.Models.Dispenser.Modules;
using VendingMachine.Shared.Domain.Models.Stock;
using VendingMachine.Shared.Domain.Models.VendingMachine;
using VendingMachine.Shared.Services;
using VendingMachine.Shared.Services.Factories;

namespace AcmeSodaConsoleApp.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public sealed class ContainerConfig
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IConsoleApplication, ConsoleApplication>();
            container.RegisterType<IConsole, CommandLineConsole>();
            container.RegisterType<IUserInput, ConsoleKeypad>();
            container.RegisterType<IUserOutput, ConsoleOutput>();

            container.RegisterType<IStockReporting, ConsoleStockReporting>();

            ConfigureSharedDomainModels(container);
            ConfigureSharedServices(container);
            ConfigureSharedInfrastructure(container);
        }

        private static void ConfigureSharedDomainModels(IUnityContainer container)
        {
            container.RegisterType<ISelectionStrategy, DispenserSelectionStrategy>();
            //container.RegisterType<IDispenserModule, SpiralDispenserModule>();
            container.RegisterType<IDispenserModule, CanDispenserModule>();

            container.RegisterType<IPaymentModule<ICashPayment>, CoinModule>();
            container.RegisterType<IVendingMachineLogic, VendingMachineLogic>();

            container.RegisterType<IPriceListService, PriceListService>();
            container.RegisterType<IStockLoaderService, StockLoaderService>();
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