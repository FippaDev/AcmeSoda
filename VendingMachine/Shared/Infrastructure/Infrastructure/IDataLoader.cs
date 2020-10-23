using System.Runtime.Serialization;

namespace Infrastructure
{
    public interface IDataLoader<T>
    {
        T Load(string filename);
    }
}