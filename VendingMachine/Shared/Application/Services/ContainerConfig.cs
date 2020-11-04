using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Domain.Models;
using VendingMachine.Shared.Services.Factories;

namespace VendingMachine.Shared.Services
{
    [ExcludeFromCodeCoverage]
    public static class ContainerConfig
    {
        public static void Configure(UnityContainer builder)
        {
            builder.RegisterType<IVendingMachineFactory, VendingMachineFactory>();
            builder.RegisterType<IVendingMachine, VendingMachine>();
            
            RegisterProjectDependencies(builder);
        }

        private static void RegisterProjectDependencies(UnityContainer builder)
        {
            ConfigureModels(builder);
            ConfigureDomain(builder);
            ConfigureInfrastructure(builder);
        }

        private static void ConfigureModels(UnityContainer builder)
        {
            builder.RegisterType<IDispenserModule, SpiralDispenserModule>();
                //new InjectionConstructor(8, 7));
        }

        private static void ConfigureDomain(UnityContainer builder)
        {
            Domain.VendingLogic.ContainerConfig.Configure(builder);
        }

        private static void ConfigureInfrastructure(UnityContainer builder)
        {
            builder.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
        }
    }
}
