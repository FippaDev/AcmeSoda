using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;

namespace Fippa.IO.Streams;

/// <summary>
/// Wrapping the IStreamReader interface, this class uses the concrete
/// (disposable) System.IO.StreamReader class.
///
/// As a basic system wrapper this does not need unit testing.
/// </summary>
[ExcludeFromCodeCoverage]
public class StreamReaderWrapper : IStreamReader
{
    private System.IO.StreamReader _stream;

    public StreamReaderWrapper(string filename)
    {
        Guard.Against.NullOrWhiteSpace(filename, nameof(filename));
        _stream = new System.IO.StreamReader(filename);
    }

    public void Load(string filename)
    {
        Guard.Against.NullOrWhiteSpace(filename, nameof(filename));
        _stream = new System.IO.StreamReader(filename);
    }

    public string ReadToEnd()
    {
        Guard.Against.Null(_stream, nameof(_stream));
        return _stream.ReadToEnd();
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}