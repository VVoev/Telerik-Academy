using SchoolSystem.Cli.Core.Providers;
using SchoolSystem.Cli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Cli
{
    class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // mujhe tum par vishvaas hai
        private ConsoleReaderProvider readProvider;
        private ConsoleWriterProvider writeProvider;

        public Engine(ConsoleReaderProvider readed,ConsoleWriterProvider writer)
        {
            this.readProvider = readed;
            this.writeProvider = writer;
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

        

        void WriteLine(string m)
        {
            var p = m.Split(); var s = string.Join(" ", p); var c = 0d;
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
        }

        internal static Dictionary<int, Teacher> teachers { get; set; } = new Dictionary<int, Teacher>();
        internal static Dictionary<int, Student> students { get; set; } = new Dictionary<int, Student>();
    }
}
