using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly ISchool school;

        public StudentListMarksCommand(ISchool school)
        {
            this.school = school;
        }
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.school.GetStudent(studentId);
            return student.ListMarks();
        }
    }
}
