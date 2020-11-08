using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;
using Unity;
using Unity.Lifetime;

namespace Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class ContainerConfig
    {
        public static void Configure(UnityContainer container)
        {
            container.RegisterType<IStreamReader, StreamReaderWrapper>();

            container.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
            container.RegisterType(typeof(IDataLoader<>), typeof(DataLoader<>), new TransientLifetimeManager());
        }
    }
}