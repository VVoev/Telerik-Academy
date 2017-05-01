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
                    var command = Console.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var commandName = command.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assemly = GetType().GetTypeInfo().Assembly;
                    var typeInfo = assemly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (typeInfo == null)
                    {
                        // throw exception when typeinfo is null
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var aadesh = Activator.CreateInstance(typeInfo) as ICommand;
                    var paramss = command.Split(' ').ToList();
                    paramss.RemoveAt(0);
                    this.WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        public void WriteLine(string message)
        {
            var messageParams = message.Split();
            var s = string.Join(" ", messageParams);

            Console.WriteLine(message);
        }
    }
}
