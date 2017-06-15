namespace ProjectManager.ConsoleClient.Configs
{
    using System;

    public interface IConfigurationProvider
    {
        TimeSpan CacheDurationInSeconds { get; }

        string LogFilePath { get; }
    }
}
