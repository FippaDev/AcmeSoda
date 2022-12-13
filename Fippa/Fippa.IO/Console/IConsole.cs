namespace Fippa.IO.Console
{
    public interface IConsole
    {
        void WriteLine(string line);
        string? ReadLine();
    }
}