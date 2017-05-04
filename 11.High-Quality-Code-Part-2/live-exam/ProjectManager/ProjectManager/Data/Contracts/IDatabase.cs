using ProjectManager.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (except to add documentation)

    /// <summary>
    /// Represent a list of all Projects
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Represent all projects in the API
        /// </summary>
        IList<IProject> Projects { get; }
    }
}
