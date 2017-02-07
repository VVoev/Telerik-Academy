using System;

namespace Tasker.Core.Providers
{
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
