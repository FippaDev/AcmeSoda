using System.Diagnostics.CodeAnalysis;
using Fippa.IO.Console;
using Unity;
using UserInterface;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public sealed class ContainerConfig
    {
        public static UnityContainer Configure(UnityContainer container)
        {
            container.RegisterType<IConsoleApplication, ConsoleApplication>();
            container.RegisterType<IConsole, CommandLineConsole>();
            container.RegisterType<IUserInput, ConsoleKeypad>();
            container.RegisterType<IUserOutput, ConsoleOutput>();

            VendingMachine.Shared.Services.ContainerConfig.Configure(container);
            Infrastructure.ContainerConfig.Configure(container);

            return container;
        }
    }
}