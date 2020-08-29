using System;
using System.IO;
using Ardalis.GuardClauses;

namespace Fippa.IO.Streams
{
    public class StreamReaderWrapper : IStreamReader, IDisposable
    {
        private readonly StreamReader _stream;

        public StreamReaderWrapper(string path)
        {
            Guard.Against.NullOrWhiteSpace(path, nameof(path));
            _stream = new StreamReader(path);
        }

        public void Dispose()
        {
            _stream?.Dispose();
        }

        public string ReadToEnd()
        {
            return _stream.ReadToEnd();
        }
    }
}