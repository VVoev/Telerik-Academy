using System;

namespace Singleton
{
   public class LogEvent
    {
        public LogEvent(string msg)
        {
            this.Message = msg;
            this.EventDate = DateTime.Now;
        }

        public string Message { get; set; }

        public DateTime EventDate { get; set; }
    }
}
