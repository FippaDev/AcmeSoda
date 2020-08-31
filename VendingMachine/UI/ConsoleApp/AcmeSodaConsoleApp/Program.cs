using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Unity;

namespace AcmeSodaConsoleApp
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main()
        {
            var container = ContainerConfig.Configure();
            var app = container.Resolve<IConsoleApplication>();
            app.Run();

            Console.WriteLine();
            Console.WriteLine("Finished. Exiting..");
            Thread.Sleep(2000);
        }
    }
}
