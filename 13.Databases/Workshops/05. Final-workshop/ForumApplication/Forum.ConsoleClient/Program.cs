using Ninject;
using System;
using System.Data.Entity;
using System.Reflection;

namespace Forum.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            IKernel kernel = BootstrapNinject();
            MyDataProvider dp = kernel.Get<MyDataProvider>();

            var category = dp.categories.GetAll(x => x.Name == "News", x => x.Name);
            Console.WriteLine(category);
        }

        private static IKernel BootstrapNinject()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
