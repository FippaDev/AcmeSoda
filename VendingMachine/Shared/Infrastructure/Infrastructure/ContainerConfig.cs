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
        public static void Configure(UnityContainer builder)
        {
            builder.RegisterType<IStreamReader, StreamReaderWrapper>();

            builder.RegisterType(typeof(IObjectSerializer<>), typeof(JsonSerialization<>), new TransientLifetimeManager());
        }
    }
}