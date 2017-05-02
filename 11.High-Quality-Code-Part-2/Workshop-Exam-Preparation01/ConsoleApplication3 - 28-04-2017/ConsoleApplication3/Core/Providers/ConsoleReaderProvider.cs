using System;

namespace SchoolSystem.CLI.Core.Providers
{
    public class ConsoleReaderProvider 
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
