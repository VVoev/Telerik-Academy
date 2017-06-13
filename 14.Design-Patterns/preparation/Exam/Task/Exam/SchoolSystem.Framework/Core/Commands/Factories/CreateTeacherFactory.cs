using SchoolSystem.Framework.Core.Commands.Factories.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using static SchoolSystem.Framework.Models.Teacher;

namespace SchoolSystem.Framework.Core.Commands.Factories
{
    public class CreateTeacherFactory : ICreateTeacherFactory
    {
        public ITeacher CreateTeacher(string firstname, string lastname, Subject subject)
        {
            return new Teacher(firstname, lastname, subject, new CreateMarkFactory());
        }
    }
}
