﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Ardalis.GuardClauses;

namespace Fippa.IO.Streams
{
    [ExcludeFromCodeCoverage]
    public class StreamWriterWrapper : IStreamWriter, IDisposable
    {
        private readonly StreamWriter _stream;

        public StreamWriterWrapper(string path)
        {
            Guard.Against.NullOrWhiteSpace(path, nameof(path));
            _stream = new StreamWriter(path);
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public void Write(string buffer)
        {
            _stream.Write(buffer);
        }
    }
}