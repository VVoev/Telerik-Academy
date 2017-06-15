namespace ProjectManager.ConsoleClient
{
    using Ninject;
    using ProjectManager.Framework.Core;

    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            var engine = kernel.Get<Engine>();
            engine.Start();

            // var configProvider = new ConfigurationProvider();
            // This is an example of how to create the caching service. Think about how and where to use it in the project.
            // var cacheService = new CachingService(configProvider.CacheDurationInSeconds);
            // var fileLogger = new FileLogger(configProvider.LogFilePath);
            // var engine = new Engine(fileLogger);
            // engine.Start();
        }
    }
}
