using System.Collections.Generic;
using System.Linq;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using Bytes2you.Validation;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateUserCommand : CreationalCommand, ICommand
    {
        private const int ParameterCountConstant = 3;

        private readonly IUserFactory userFactory;
        private readonly IAddUser addUser;

        public CreateUserCommand(ModelsFactory factory, IUserFactory userFactory, IAddUser addUser)
            : base(factory)
        {
            Guard.WhenArgument(factory, "userFactory").IsNull().Throw();
            Guard.WhenArgument(addUser, "addUser").IsNull().Throw();

            this.userFactory = userFactory;
            this.addUser = addUser;
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var projectId = int.Parse(parameters[0]);
            var project = this.Database.Projects[projectId];

            if (project.Users.Any() && project.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.userFactory.CreateUser(parameters[1], parameters[2]);
            this.addUser.AddUser(projectId, user);

            return "Successfully created a new user!";
        }
    }
}
