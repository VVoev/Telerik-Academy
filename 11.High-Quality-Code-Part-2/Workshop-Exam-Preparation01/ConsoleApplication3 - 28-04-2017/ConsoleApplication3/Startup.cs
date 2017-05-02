namespace SchoolSystemCli
{
    // I am not responsible of this code.
    // They made me write it, against my will.
    ////- Steven, October 2016, Telerik Academy

    using SchoolSystem.CLI.Core.Providers;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(reader);
        }
    }
}
