using SchoolSystem.CLI.Core;
using SchoolSystem.CLI.Core.Providers;

namespace SchoolSystemCli
{
    // I am not sure if we need this, but too scared to delete. 
    public class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider padhana)
        {
            var engine = new Engine(padhana);
            engine.Start();
        }
    }
}
