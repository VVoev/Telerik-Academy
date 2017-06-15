﻿using System.Collections.Generic;
using System.Linq;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateProjectCommand : CreationalCommand, ICommand
    {
        private readonly IProjectFactory projectFactory;
        private readonly IAddProject addProject;

        private const int ParameterCountConstant = 4;

        public CreateProjectCommand(ModelsFactory factory,IAddProject addProject, IProjectFactory projectFactory)
            : base(factory)
        {
            this.projectFactory = projectFactory;
            this.addProject = addProject;
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

            if (this.Database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.Factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.addProject.AddProject(project);

            return "Successfully created a new project!";
        }
    }
}
