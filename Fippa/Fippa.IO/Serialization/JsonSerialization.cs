﻿using Ardalis.GuardClauses;
using Fippa.IO.Streams;
using Newtonsoft.Json;

namespace Fippa.IO.Serialization;

public class JsonSerialization<T> : IObjectSerializer<T> where T : new()
{
    public void Save(IStreamWriter streamWriter, T objectToSerialize)
    {
        Guard.Against.Null(streamWriter, nameof(streamWriter));
        Guard.Against.Null(objectToSerialize, nameof(objectToSerialize));

        var settings = new JsonSerializerSettings();
        string json = JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, settings);

        streamWriter.Write(json);
    }

    public T Load(IStreamReader streamReader)
    {
        Guard.Against.Null(streamReader, nameof(streamReader));

        var json = streamReader.ReadToEnd();

        var obj = JsonConvert.DeserializeObject<T>(json);
        return obj ?? new T();
    }
}