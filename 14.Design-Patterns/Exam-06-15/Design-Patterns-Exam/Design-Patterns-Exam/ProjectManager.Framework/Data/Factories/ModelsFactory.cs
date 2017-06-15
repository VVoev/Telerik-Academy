using System;

using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data.Models;
using ProjectManager.Framework.Data.Models.States;

namespace ProjectManager.Framework.Data.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly IValidator validator;
        private readonly IModelsFactory modelsFactory;

        public ModelsFactory(IValidator validator, IModelsFactory modelsFactory)
        {
            Guard.WhenArgument(validator, "ModelsFactory Validator").IsNull().Throw();
            this.validator = validator;
            this.modelsFactory = modelsFactory;
        }

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime startingDateParsed;
            DateTime endingDateParsed;
            ProjectState stateParsed;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out startingDateParsed);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out endingDateParsed);
            var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed project state!");
            }

            var project = this.modelsFactory.CreateProject(name, startingDateParsed.ToString(), endingDateParsed.ToString(), stateParsed.ToString());
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            TaskState stateParsed;
            var stateSuccessful = Enum.TryParse(state, true, out stateParsed);

            if (!stateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed Task state!");
            }

            var task = this.modelsFactory.CreateTask(new User("vlado", "kk"), name, state);
            this.validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = this.modelsFactory.CreateUser(username, email);
            this.validator.Validate(user);

            return user;
        }
    }
}
