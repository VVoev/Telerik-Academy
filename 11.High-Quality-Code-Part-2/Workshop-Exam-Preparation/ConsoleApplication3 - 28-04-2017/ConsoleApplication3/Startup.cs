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
            var provider = new ConsoleReaderProvider();
            var service = new BusinessLogicService();
            service.Execute(provider);
        }
    }
}
