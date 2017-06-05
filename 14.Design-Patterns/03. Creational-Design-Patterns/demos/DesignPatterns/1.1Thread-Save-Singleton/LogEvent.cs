namespace Thread_Save_Singleton
{
    public class LogEvent
    {
        public LogEvent(object msg)
        {
            this.Message = msg;
        }

        public object Message { get; set; }
    }
}