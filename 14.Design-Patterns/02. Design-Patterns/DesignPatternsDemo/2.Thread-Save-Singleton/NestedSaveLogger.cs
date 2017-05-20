using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _2.Thread_Save_Singleton
{
    class NestedSaveLogger
    {
        private readonly List<LogEvent> events;

        private NestedSaveLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static NestedSaveLogger Instance
        {
            get
            {
                return SingletonContainer.Instance;
            }
        }

        public void SaveToLog(string msg)
        {
            this.events.Add(new LogEvent(msg));
        }

        public void PrintLog()
        {
            foreach (var ev in this.events)
            {
                System.Console.WriteLine($@"{ev.Message} with date:{ev.EventDate} and some other shits {ev.GetType().Name}");
            }
        }

        private static class SingletonContainer
        {
            internal static readonly NestedSaveLogger Instance = new NestedSaveLogger();

            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            // which will initialize the fields (Instance) just before their first use (not earlier)
            [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1409:RemoveUnnecessaryCode",
                Justification = "Reviewed. Suppression is OK here.")]
            static SingletonContainer()
            {
            }
        }
    }
}
