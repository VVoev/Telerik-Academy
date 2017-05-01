using ConsoleApplication3;

namespace StudentApplication
{
    public class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider input)
        {
            var engine = new Engine(input);
            engine.Start();
        }
    }
}
