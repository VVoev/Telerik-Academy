using System;
using System.Collections.Generic;

namespace Thread_Save_Singleton
{
    public sealed class LazyThreadSafeLogger
    {
        private static readonly Lazy<LazyThreadSafeLogger> Lazy = new Lazy<LazyThreadSafeLogger>(() => new LazyThreadSafeLogger());

        private readonly List<LogEvent> events;

        private LazyThreadSafeLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static LazyThreadSafeLogger Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        public void Save(object msg)
        {
            this.events.Add(new LogEvent(msg));
        }

        public void Print()
        {
            foreach (var msg in this.events)
            {
                Console.WriteLine(msg.Message);
            }
        }
    }
}