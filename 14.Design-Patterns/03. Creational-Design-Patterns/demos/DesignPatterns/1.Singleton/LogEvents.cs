namespace Singleton
{
    public class LogEvents
    {
        public LogEvents(string msg)
        {
            this.Message = msg;
        }

        public string Message { get; set; }
    }
}