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
        public static void Configure(UnityContainer builder)
        {
            builder.RegisterType<IVendingMachineFactory, VendingMachineFactory>();
            builder.RegisterType<IVendingMachine, VendingMachine>();
            
            RegisterProjectDependencies(builder);
        }

        private static void RegisterProjectDependencies(UnityContainer builder)
        {
            Domain.VendingLogic.ContainerConfig.Configure(builder);
            ConfigureInfrastructure(builder);
        }

        private static void ConfigureInfrastructure(UnityContainer builder)
        {
            builder.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
        }
    }
}
