using System.Collections.Generic;

namespace SchoolSystem.Cli.Core.Commands
{
    class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teecherid = int.Parse(prms[0]);
            var studentid = int.Parse(prms[1]);
            // Please work
            var student = Engine.students[teecherid];
            var adhyaapak = Engine.teachers[studentid];
            adhyaapak.AddMark(student, float.Parse(prms[2]));
            return $"Teacher {adhyaapak.FirstName} {adhyaapak.LastName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {adhyaapak.Subject}.";
        }
    }
}
