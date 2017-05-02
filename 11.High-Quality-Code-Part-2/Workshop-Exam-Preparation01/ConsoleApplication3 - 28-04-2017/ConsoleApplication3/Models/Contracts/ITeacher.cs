namespace SchoolSystem.CLI.Models.Contracts
{
    using SchoolSystemCli.Models.Enums;
    
    /// <summary>
    /// Represent a Teacher with extend Person with atributes Subject and AddMark function
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get;  }

        /// <summary>
        /// Add mark on a student
        /// </summary>
        /// <param name="student">The student which have the mark</param>
        /// <param name="currentMark">mark a student deserve</param>
        /// 
         void AddMark(IStudent student, float currentMark);
    }
}
