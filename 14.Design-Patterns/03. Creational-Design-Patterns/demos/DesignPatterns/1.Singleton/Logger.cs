using System;
using System.Collections.Generic;

namespace Singleton
{
    public  class Logger
    {
        private static Logger instance;
        private readonly List<LogEvents> messages;

        private Logger()
        {
            this.messages = new List<LogEvents>();
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void Save(string msg)
        {
            this.messages.Add(new LogEvents(msg));
        }

        public void Print()
        {
            foreach (var msg in this.messages)
            {
               Console.WriteLine(msg.Message);
            }
        }
    }
}