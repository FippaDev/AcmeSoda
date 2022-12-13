namespace Infrastructure;

public interface IDataLoader<out T>
{
    T Load(string filename);
}