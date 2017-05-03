namespace SchoolSystem
{
    using System.Reflection;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    class Startup
    {
        static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var padhana = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(padhana);
        }
    }
    class ConsoleReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
    class Engine
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

        void WriteLine(string message)
        {
            var p = message.Split();
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
                    throw new ArgumentException($@"Invalid parse: {message} ");
                }
            }
            Console.Write("\n");
        }

        internal static Dictionary<int, Teacher> teachers { get; set; } = new Dictionary<int, Teacher>();
        internal static Dictionary<int, Student> students { get; set; } = new Dictionary<int, Student>();
    }
}
