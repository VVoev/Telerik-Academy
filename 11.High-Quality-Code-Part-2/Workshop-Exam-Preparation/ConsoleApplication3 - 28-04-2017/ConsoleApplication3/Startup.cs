namespace StudentApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Models;

    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var padhana = new ConsoleReaderProvider();
            var service = new BusinessLogicService();
            service.Execute(padhana);
        }
    }
}
