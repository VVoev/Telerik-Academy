using System;

namespace _2.Thread_Save_Singleton
{
    class LogEvent
    {
        public LogEvent(string message)
        {
            this.Message = message;
            this.EventDate = DateTime.Now;
        }

        public string Message { get; private set; }

        public DateTime EventDate { get; private set; }
    }
}
