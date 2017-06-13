using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands.Factories.Contracts
{
    public interface ICreateStudentFactory
    {
        IStudent CreateStudent(string firstname, string lastname, Grade grade);
    }

    public interface ICreateTeacherFactory
    {
        ITeacher CreateTeacher(string firstname, string lastname, Subject subject);
    }
}
