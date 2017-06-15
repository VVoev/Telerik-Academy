namespace ProjectManager.ConsoleClient.Configs
{
    using System;
    using System.Configuration;

    public class ConfigurationProvider : IConfigurationProvider
    {
        public TimeSpan CacheDurationInSeconds
        {
            get
            {
                return TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["CacheTime"]));
            }
        }

        public string LogFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["LogFilePath"];
            }
        }
    }
}
