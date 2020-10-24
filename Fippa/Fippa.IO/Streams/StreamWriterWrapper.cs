using System.IO;
using Ardalis.GuardClauses;

namespace Fippa.IO.Streams
{
    public class StreamWriterWrapper : IStreamWriter
    {
        private readonly StreamWriter _stream;

        public StreamWriterWrapper(string path)
        {
            Guard.Against.NullOrWhiteSpace(path, nameof(path));
            _stream = new StreamWriter(path);
        }

        public void Write(string buffer)
        {
            _stream.Write(buffer);
        }

        public void Dispose()
        {
            _stream.Dispose();
        }
    }
}