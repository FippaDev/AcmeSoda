using System;
using Ardalis.GuardClauses;
using Fippa.IO.Serialization;
using Fippa.IO.Streams;

namespace Infrastructure;

public class DataLoader<T> : IDisposable, IDataLoader<T>
{
    private readonly IStreamReader _streamReader;
    private readonly IObjectSerializer<T> _serializer;

    public DataLoader(IStreamReader streamReader, IObjectSerializer<T> serializer)
    {
        Guard.Against.Null(streamReader, nameof(streamReader));
        Guard.Against.Null(serializer, nameof(serializer));

        _streamReader = streamReader;
        _serializer = serializer;
    }

    public T Load(string filename)
    {
        _streamReader.Load(filename);
        return _serializer.Load(_streamReader);
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}