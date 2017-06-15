using System.Collections.Generic;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateTaskCommand : CreationalCommand, ICommand
    {
        private readonly ITaskFactory taskFactory;
        private readonly IAddTask addTask;

        private const int ParameterCountConstant = 4;

        public CreateTaskCommand(ModelsFactory factory, ITaskFactory taskFactory, IAddTask addTask)
            : base(factory)
        {
            this.taskFactory = taskFactory;
            this.addTask = addTask;
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

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var task = this.Factory.CreateTask(owner, parameters[2], parameters[3]);
            this.addTask.AddTask(projectId, ownerId, parameters[2], parameters[3]);

            return "Successfully created a new task!";
        }
    }
}
