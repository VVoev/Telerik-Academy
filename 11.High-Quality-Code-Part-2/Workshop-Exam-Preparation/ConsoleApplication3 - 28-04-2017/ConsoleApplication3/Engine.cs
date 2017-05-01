namespace StudentApplication
{
    using ConsoleApplication3;
    using StudentApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    public class Engine
    {
        private ConsoleReaderProvider read;

        public Engine(ConsoleReaderProvider readed)
        {
            this.read = readed;
        }

        public static Dictionary<int, Teacher> Teachers { get; set; } = new Dictionary<int, Teacher>();

        public static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

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
                    this.WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        public void WriteLine(string m)
        {
            var p = m.Split();
            var s = string.Join(" ", p);

            for (double i = 0; i < 0x105; i++)
            {
                try
                {
                    Console.Write(s[int.Parse(i.ToString())]);
                }
                catch (Exception)
                {
                }
            }

            Console.Write("\n");
            Thread.Sleep(350);
        }
    }
}
