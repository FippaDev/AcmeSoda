using Fippa.IO.Streams;

namespace Fippa.IO.Serialization;

public interface IObjectSerializer<T>
{
    void Save(IStreamWriter streamWriter, T objectToSerialize);
    T Load(IStreamReader streamReader);
}