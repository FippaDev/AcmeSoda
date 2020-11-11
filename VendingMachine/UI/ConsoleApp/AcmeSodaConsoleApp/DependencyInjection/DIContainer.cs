using Fippa.DependencyInjection;
using Unity;

namespace AcmeSodaConsoleApp.DependencyInjection
{
    public sealed class DependencyInjectionContainer : IDependencyInjectionContainer
    {
        public IUnityContainer Unity { get; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DependencyInjectionContainer()
        {
        }

        private DependencyInjectionContainer()
        {
            Unity = new UnityContainer();
        }

        public static DependencyInjectionContainer Instance { get; } = new DependencyInjectionContainer();
    }
}
