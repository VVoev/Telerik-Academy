using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Commands;
using static SchoolSystem.Framework.Core.Commands.CreateStudentCommand;
using static SchoolSystem.Framework.Core.Commands.CreateTeacherCommand;

namespace SchoolSystem.Framework.Core.Providers
{
    public interface ICommandFactory
    {
        ICommand GetCommand(Type type);
    }
    //public static class CommandFactory
    //{
    //    public static ICommand GetCommand(string command)
    //    {
    //        switch (command)
    //        {
    //            case "CreateStudent": return new CreateStudentCommand(new StudenFactory());
    //            case "CreateTeacher": return new CreateTeacherCommand(new TeacherFactory());
    //        }
    //        return null;
    //    }
    //}
    public class CommandParserProvider : IParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParserProvider(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);

            var command = this.commandFactory.GetCommand(commandTypeInfo);

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
