using ProjectManager.Models;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Describers information about current models
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Method whih create project
        /// </summary>
        /// <param name="name">Name of the project</param>
        /// <param name="startingDate">Starting date of the project</param>
        /// <param name="endingDate">Ending date of the project</param>
        /// <param name="state">State of the project</param>
        /// <returns></returns>
        Project CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Method which create new task
        /// </summary>
        /// <param name="owner">Owner of the task</param>
        /// <param name="name">Name of the task</param>
        /// <param name="state">State of the task</param>
        /// <returns></returns>
        Task CreateTask(User owner, string name, string state);

        /// <summary>
        /// Method which create User
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="email">Email of the user</param>
        /// <returns></returns>
        User CreateUser(string username, string email);
    }
}
