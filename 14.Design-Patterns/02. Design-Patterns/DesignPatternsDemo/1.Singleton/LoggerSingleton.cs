using System.Collections.Generic;

namespace Singleton
{
    public class LoggerSingleton
    {
        private static LoggerSingleton instance;

        private readonly List<LogEvent> events = new List<LogEvent>();

        private LoggerSingleton()
        {
        }

        public static LoggerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggerSingleton();
                }
                return instance;
            }
        }

        public void SaveToLog(string msg)
        {
            events.Add(new LogEvent(msg));
        }

        public void PrintLog()
        {
            foreach (var ev in this.events)
            {
                System.Console.WriteLine($@"{ev.Message} with date {ev.EventDate}");
            }
        }

    }
}
