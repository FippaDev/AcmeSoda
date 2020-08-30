using System.Diagnostics.CodeAnalysis;
using Unity;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ContainerConfig
    {
        public static UnityContainer Configure()
        {
            var builder = new UnityContainer();

            builder.RegisterType<IConsoleApplication, ConsoleApplication>();
            builder.RegisterType<ICommandLineMenu, CommandLineMenu>();

            Services.ContainerConfig.Configure(builder);

            return builder;
        }
    }
}