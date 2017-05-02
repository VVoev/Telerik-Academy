using System;
using SchoolSystem.CLI.Core.Commands.Contracts;

namespace SchoolSystem.CLI.Core.Providers
{
    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string msg)
        {
             Console.Write(msg);
        }

        public void WriteLine(string msg)
        {
             Console.WriteLine(msg);
        }
    }
}
