using Unity;

namespace Fippa.DependencyInjection
{
    public interface IDIContainer
    {
        IUnityContainer Unity { get; }
    }
}