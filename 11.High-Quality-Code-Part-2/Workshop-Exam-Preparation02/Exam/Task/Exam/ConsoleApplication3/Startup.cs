namespace SchoolSystem
{
    using Cli;
    using Cli.Core.Providers;

    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var readProvider = new ConsoleReaderProvider();
            var writeProvider = new ConsoleWriterProvider();


            var engine = new Engine(readProvider,writeProvider);
            engine.Start();
        }
    }
    
}
