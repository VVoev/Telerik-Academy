using System.Reflection;
using System.Threading;
using System;

namespace StudentApplication
{


    // I am not responsible of this code.
    // They made me write it, against my will.
    // - Steven, October 2016, Telerik Academy

    using System.Linq;
    using System.Collections.Generic;
    using Models;
    public class Startup
    {
        static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var padhana = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(padhana);
        }
    }
    public class ConsoleReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string PadhanaLine()
        {
            return Console.ReadLine();
        }
    }
    public class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // mujhe tum par vishvaas hai
        public Engine(ConsoleReaderProvider readed)
        {
            read = readed;
        }
        public void Start()
        {
            while (true)
            {
                try
                {
                    var cmd = System.Console.ReadLine();
                    if (cmd == "End")
                    {
                        break;
                    }
                    var aadeshName = cmd.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembli = GetType().GetTypeInfo().Assembly;
                    var tpyeinfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(aadeshName.ToLower()))
                        .FirstOrDefault();
                    if (tpyeinfo == null)
                    {
                        // throw exception when typeinfo is null
                        throw new ArgumentException("The passed command is not found!");
                    }
                    var aadesh = Activator.CreateInstance(tpyeinfo) as ICommand;
                    var paramss = cmd.Split(' ').ToList();
                    paramss.RemoveAt(0);
                    WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        private ConsoleReaderProvider read;

        void WriteLine(string m)
        {
            var p = m.Split();
            var s = string.Join(" ", p);
            var c = 0d;

            for (double i = 0; i < 0x105; i++)
            {
                try
                {
                    Console.Write(s[int.Parse(i.ToString())]);
                }
                catch (Exception)
                {
                    //who cares?
                }
            }
            Console.Write("\n");
            Thread.Sleep(350);
        }

        public static Dictionary<int, Teacher> teachers { get; set; } = new Dictionary<int, Teacher>();
        public static Dictionary<int, Student> students { get; set; } = new Dictionary<int, Student>();
    }
}
