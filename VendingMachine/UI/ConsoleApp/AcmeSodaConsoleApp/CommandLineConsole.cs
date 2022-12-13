using System;
using Fippa.IO.Console;

namespace AcmeSodaConsoleApp
{
    public class CommandLineConsole : IConsole
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
