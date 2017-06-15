using System.Collections.Generic;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using Bytes2you.Validation;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public sealed class ListProjectDetailsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 1;
        private readonly IProjectInfo projectInfo;

        public ListProjectDetailsCommand(IProjectInfo projectInfo)
        {
            Guard.WhenArgument(projectInfo, "projectInfo").IsNull().Throw();

            this.projectInfo = projectInfo;
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
            if (this.Database.Projects.Count <= projectId || projectId < 0)
            {
                throw new UserValidationException("The project is not present in the database");
            }

            var project = this.projectInfo.GetProjectInfo(projectId);

            return project;
        }
    }
}
