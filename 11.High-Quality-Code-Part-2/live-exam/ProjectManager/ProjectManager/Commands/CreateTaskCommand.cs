using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        public string Execute(List<string> parameters)
        {
            var database = new Database();

            var factory = new ModelsFactory();

            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var project = database.Projects[int.Parse(parameters[0])];
            var owner = project.Users[int.Parse(parameters[1])];
            var task = factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
