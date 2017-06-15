using System;
using System.Collections.Generic;

using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public class ListProjectsCommand : Command, ICommand
    {
        private readonly IProjectsInfo projectsInfo;
        private const int ParameterCountConstant = 0;

        public ListProjectsCommand(IProjectsInfo projectsInfo)
        {
            this.projectsInfo = projectsInfo;
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

            var projects = this.projectsInfo.GetProjectsInfo();

            return projects;
        }
    }
}
