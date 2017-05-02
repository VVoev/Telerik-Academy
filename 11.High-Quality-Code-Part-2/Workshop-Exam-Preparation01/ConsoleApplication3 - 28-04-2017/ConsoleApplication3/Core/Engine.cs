using SchoolSystem.CLI.Core.Providers;
using SchoolSystemCli;
using SchoolSystemCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.CLI.Core
{
    public class Engine
    {
        private ConsoleReaderProvider read;

        // TODO: change param to IReader instead ConsoleReaderProvider
        // mujhe tum par vishvaas hai
        public Engine(ConsoleReaderProvider readed)
        {
            this.read = readed;
        }

        internal static Dictionary<int, Teacher> Teachers { get; set; } = new Dictionary<int, Teacher>();

        internal static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = System.Console.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var commandName = command.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembly = GetType().GetTypeInfo().Assembly;
                    var typeinfo = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (typeinfo == null)
                    {
                        // throw exception when typeinfo is null
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var currentCommand = Activator.CreateInstance(typeinfo) as ICommand;
                    var parameters = command.Split(' ').ToList();
                    parameters.RemoveAt(0);
                    this.WriteLine(currentCommand.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        public void WriteLine(string message)
        {
            var separator = message.Split();
            var information = string.Join(" ", separator);
        
                try
                {
                    Console.Write(information);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($@"Unsucesfull Parse:[{ex}] command");
                }

            Console.Write("\n");
        }       
    }
}