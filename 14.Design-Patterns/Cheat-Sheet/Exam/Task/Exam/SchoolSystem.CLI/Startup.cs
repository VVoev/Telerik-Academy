using Ninject;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Providers;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {

            var kernel = new StandardKernel(new SchoolSystemModule());
            var engine = kernel.Get<Engine>();
            engine.Start();


            //var reader = new ConsoleReaderProvider();
            //var writer = new ConsoleWriterProvider();
            //var parser = new CommandParserProvider();
            //var engine = new Engine(reader, writer, parser);
            //engine.Start();
        }
    }
}