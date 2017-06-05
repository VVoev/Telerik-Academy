using System;
using _3.FactoryMethod.Manufacturer;
using System;
using System.Configuration;
using System.Reflection;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithPhone(new Apple());
            Console.WriteLine();

            WorkWithPhone(new Samsung());
            Console.WriteLine();

            WorkWithPhone(new LG());
            Console.WriteLine();

        }

        private static void WorkWithPhone(Manufacturer manufacturer)
        {
            var phone = manufacturer.ManufactureGSM();
            Console.WriteLine(phone);
            phone.Start();
        }
    }
}
