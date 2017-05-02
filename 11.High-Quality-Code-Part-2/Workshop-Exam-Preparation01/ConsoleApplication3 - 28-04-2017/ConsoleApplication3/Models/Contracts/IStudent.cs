namespace SchoolSystem.CLI.Models.Contracts
{
    using SchoolSystemCli.Models;
    using SchoolSystemCli.Models.Enums;
    using System.Collections.Generic;
    
    /// <summary>
    /// Represent a Student and Extend Person,Student have Grade and Marks and the way it dipslays the Marks
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get;  }

        IList<Mark> Marks { get;  }

        /// <summary>
        /// Generate a list of students marks
        /// </summary>
        /// <returns>Return a string with the marks,if there is no marks it shows error message</returns>
        string ListMarks();
    }
}
