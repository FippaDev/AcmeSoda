using Fippa.DependencyInjection;
using Unity;

namespace AcmeSodaConsoleApp.DependencyInjection
{
    public sealed class DIContainer : IDIContainer
    {
        public IUnityContainer Unity { get; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DIContainer()
        {
        }

        private DIContainer()
        {
            Unity = new UnityContainer();
        }

        public static DIContainer Instance { get; } = new DIContainer();
    }
}
