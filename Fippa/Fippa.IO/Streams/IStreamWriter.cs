using System;

namespace Fippa.IO.Streams
{
    public interface IStreamWriter : IDisposable
    {
        void Write(string buffer);
    }
}