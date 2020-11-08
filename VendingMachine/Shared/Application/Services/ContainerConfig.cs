using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Unity;
using Unity.Lifetime;
using VendingMachine.Shared.Domain.Domain.VendingMachine;
using VendingMachine.Shared.Services.Factories;

namespace VendingMachine.Shared.Services
{
    [ExcludeFromCodeCoverage]
    public static class ContainerConfig
    {
        public static void Configure(UnityContainer container)
        {
            container.RegisterType<IVendingMachineFactory, VendingMachineFactory>();
            container.RegisterType<IVendingMachine, VendingMachine>();
            
            RegisterProjectDependencies(container);
        }

        private static void RegisterProjectDependencies(UnityContainer builder)
        {
            ConfigureModels(builder);
            ConfigureDomain(builder);
            ConfigureInfrastructure(builder);
        }

        private static void ConfigureModels(UnityContainer builder)
        {
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