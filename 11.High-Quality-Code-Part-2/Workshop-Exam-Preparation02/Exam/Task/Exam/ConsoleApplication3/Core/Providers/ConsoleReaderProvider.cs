using SchoolSystem.Cli.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Cli.Core.Providers
{
    class ConsoleReaderProvider : IReader
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
