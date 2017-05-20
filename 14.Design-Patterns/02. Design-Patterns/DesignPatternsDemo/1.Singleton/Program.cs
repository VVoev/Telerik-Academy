namespace Singleton
{
    class SingletonApi
    {
        static void Main(string[] args)
        {
            var logger = LoggerSingleton.Instance;
            logger.SaveToLog("Kvo stana");
            logger.SaveToLog("Trqbva da xodq na lekcii");
            var logger2 = LoggerSingleton.Instance;
            logger2.SaveToLog("Kvo stana 2");
            logger.PrintLog();


        }
    }
}
