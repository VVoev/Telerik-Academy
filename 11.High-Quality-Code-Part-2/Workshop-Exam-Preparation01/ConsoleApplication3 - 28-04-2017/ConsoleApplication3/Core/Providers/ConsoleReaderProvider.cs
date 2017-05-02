using SchoolSystem.CLI.Core.Commands.Contracts;
using System;

namespace SchoolSystem.CLI.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
