using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using ProjectManager.Data;
using ProjectManager.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Execute(List<string> parameters)
        {
            var database = new Database();
            var engine = new ModelsFactory();

            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (database.Projects[int.Parse(parameters[0])].Users.Any() && database.Projects[int.Parse(parameters[0])].Users.Any(x => x.UserName == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            database.Projects[int.Parse(parameters[0])].Users.Add(engine.CreateUser(parameters[1], parameters[2]));

            return "Successfully created a new user!";
        }
    }
}
