using ProjectManager.Framework.Core.Commands.Contracts;

namespace ProjectManager.Framework.Data
{
    public interface IDatabase : IAddProject, IAddTask, IAddUser, IProjectInfo, IProjectsInfo
        {
        }
}
