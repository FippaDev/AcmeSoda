using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Services.Factories;
using Unity;
using Unity.Lifetime;

namespace Services
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
            VendingLogic.ContainerConfig.Configure(builder);
            ConfigureInfrastructure(builder);
        }

        public static void ConfigureInfrastructure(UnityContainer builder)
        {
            builder.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
        }
    }
}
