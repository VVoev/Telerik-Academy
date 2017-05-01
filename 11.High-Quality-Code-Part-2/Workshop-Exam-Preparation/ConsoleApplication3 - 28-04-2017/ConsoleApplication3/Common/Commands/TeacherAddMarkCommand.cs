using StudentApplication;
using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teecherid = int.Parse(parameters[0]);
            var studentid = int.Parse(parameters[1]);

            var student = Engine.Students[teecherid];
            var teacher = Engine.Teachers[studentid];

            teacher.AddMark(student, float.Parse(parameters[2]));

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
