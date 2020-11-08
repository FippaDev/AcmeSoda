using Unity;

namespace AcmeSodaConsoleApp
{
    public sealed class DependencyContainer
    {
        private static readonly DependencyContainer _instance = new DependencyContainer();
        private readonly UnityContainer _unityContainer;

        public UnityContainer Unity => _unityContainer;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DependencyContainer()
        {
        }

        private DependencyContainer()
        {
            _unityContainer = new UnityContainer();
        }

        public static DependencyContainer Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
