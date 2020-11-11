using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AcmeSodaConsoleApp.DependencyInjection;
using Unity;
using Unity.Resolution;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
        {
            var unityContainer = DIContainer.Instance.Unity;
            ContainerConfig.Configure(unityContainer);

            var app = unityContainer.Resolve<IConsoleApplication>(
                new ResolverOverride[]
                {
                    new ParameterOverride("unity", unityContainer)
                });
            app.Run();

            Console.WriteLine();
            Console.WriteLine("Finished. Exiting..");
            Thread.Sleep(2000);
        }
    }
}
