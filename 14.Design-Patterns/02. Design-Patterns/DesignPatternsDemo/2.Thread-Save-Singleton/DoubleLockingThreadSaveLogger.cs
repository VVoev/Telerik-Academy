using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Thread_Save_Singleton
{
    class DoubleLockingThreadSaveLogger
    {
        private static volatile DoubleLockingThreadSaveLogger logger;

        private static object syncLock = new object();

        private readonly List<LogEvent> events;

        private DoubleLockingThreadSaveLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static DoubleLockingThreadSaveLogger Instance
        {
            get
            {
                if(logger == null)
                {
                    lock (syncLock)
                    {
                        if(logger == null)
                        {
                            logger = new DoubleLockingThreadSaveLogger();
                        }
                    }
                }
                return logger;
            }

        }
        public void SaveToLog(object message)
        {
            this.events.Add(new LogEvent(message.ToString()));
        }

        public void PrintLog()
        {
            foreach (var ev in this.events)
            {
                Console.WriteLine("Time: {0}, Event: {1}", ev.EventDate.ToShortTimeString(), ev.Message);
            }
        }
    }
}
