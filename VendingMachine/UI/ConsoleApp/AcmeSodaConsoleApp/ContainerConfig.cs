using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Console;
using Unity;
using UserInterface;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ContainerConfig
    {
        public static UnityContainer Configure()
        {
            var builder = new UnityContainer();

            builder.RegisterType<IConsoleApplication, ConsoleApplication>();
            builder.RegisterType<IConsole, CommandLineConsole>();
            builder.RegisterType<IUserInput, ConsoleKeypad>();
            builder.RegisterType<IUserOutput, ConsoleOutput>();

            Services.ContainerConfig.Configure(builder);

            return builder;
        }
    }
}