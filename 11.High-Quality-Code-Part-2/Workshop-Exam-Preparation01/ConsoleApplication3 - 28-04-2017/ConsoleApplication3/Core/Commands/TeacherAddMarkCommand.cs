using SchoolSystemCli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.CLI.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentid = int.Parse(parameters[1]);

            var student = Engine.Students[studentid];
            var teacher = Engine.Teachers[teacherId];

            teacher.AddMark(student, float.Parse(parameters[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
