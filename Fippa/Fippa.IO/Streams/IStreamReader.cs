using System;

namespace Fippa.IO.Streams;

public interface IStreamReader : IDisposable
{
    void Load(string filename);
    string ReadToEnd();
}