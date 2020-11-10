using Unity;

namespace AcmeSodaConsoleApp
{
    public sealed class DependencyContainer
    {
        public UnityContainer Unity { get; }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DependencyContainer()
        {
        }

        private DependencyContainer()
        {
            Unity = new UnityContainer();
        }

        public static DependencyContainer Instance { get; } = new DependencyContainer();
    }
}
