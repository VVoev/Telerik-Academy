using System.Collections.Generic;
using System;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Models;
using ProjectManager.Framework.Core.Commands.Contracts;
using System.Linq;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Data
{
    // You are not allowed to modify this class (not even to remove this comment)
    public class Database : IDatabase
    {
        private readonly IList<IProject> projects;
        private readonly ITaskFactory taskFactory;

        public Database(ITaskFactory taskFactory)
        {
            this.projects = new List<IProject>();
            this.taskFactory = taskFactory;
        }

    

        public IList<IProject> Projects
        {
            get
            {
                return this.projects;
            }
        }

        public void AddProject(IProject project)
        {
            if (this.projects.Any(x => x.Name == project.Name))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            this.projects.Add(project);
        }

        public void AddTask(int projectId, int ownerId, string taskName, string taskState)
        {
            var project = this.projects[projectId];
            var owner = project.Users[ownerId];

            var task = this.taskFactory.GetTask(owner, taskName, taskState);
            project.Tasks.Add(task);
        }

        public void AddUser(int projectId, IUser user)
        {
            var project = this.projects[projectId];

            if (project.Users.Any() && project.Users.Any(x => x.Username == user.Username))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            project.Users.Add(user);
        }

        public string GetProjectInfo(int projectId)
        {
            var project = this.projects[projectId];

            return project.ToString();
        }

        public string GetProjectsInfo()
        {
            var projects = string.Join(Environment.NewLine, this.projects);
            return projects;
        }
    }
}
