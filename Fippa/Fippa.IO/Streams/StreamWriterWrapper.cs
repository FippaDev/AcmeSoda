using System.Diagnostics.CodeAnalysis;
using System.IO;
using Ardalis.GuardClauses;

namespace Fippa.IO.Streams
{
    /// <summary>
    /// Wrapping the IStreamReader interface, this class uses the concrete
    /// (disposable) System.IO.StreamReader class.
    ///
    /// As a basic system wrapper this does not need unit testing.
    /// </summary>
    [ExcludeFromCodeCoverage]
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