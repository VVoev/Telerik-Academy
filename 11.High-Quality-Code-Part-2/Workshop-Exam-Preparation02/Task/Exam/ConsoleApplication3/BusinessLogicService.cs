namespace SchoolSystem
{

    // I am not sure if we need this, but too scared to delete. 
    class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider command)
        {
            var engine = new Engine(command);
            engine.Start();
        }
    }
}
