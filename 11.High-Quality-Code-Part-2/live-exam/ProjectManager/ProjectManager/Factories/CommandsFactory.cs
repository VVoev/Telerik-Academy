using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories;
using ProjectManager.Factories.Contracts;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;
using System;

namespace ProjectManager.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private Database db;

        private ModelsFactory engine;

        public CommandsFactory(Database db, ModelsFactory engine)
        {
            this.db = db;
            this.engine = engine;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.BuildCommand(commandName);

            switch (command)
            {
                case "createproject": return new CreateProjectCommand(this.db, this.engine);
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(this.db);
                case "createuser": return new CreateUserCommand();
                case "listprojectdetails": return new ListProjectDetails(this.db);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = parameters.ToLower();
            return command;
        }
    }
}