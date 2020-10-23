using System.Runtime.Serialization;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;

namespace Infrastructure
{
    public class DataLoader<T> : IDataLoader<T> where T : ISerializable
    {
        private readonly IStreamReader _streamReader;
        private readonly IObjectSerializer<T> _serializer;

        public DataLoader(IStreamReader streamReader, IObjectSerializer<T> serializer)
        {
            _streamReader = streamReader;
            _serializer = serializer;
        }

        public T Load(string filename)
        {
            //using var reader = new StreamReaderWrapper(filename);
            return _serializer.Load(_streamReader);
        }
    }
}
