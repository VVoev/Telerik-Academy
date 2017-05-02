using SchoolSystemCli;
using SchoolSystemCli.Models;
using SchoolSystemCli.Models.Enums;
using System.Collections.Generic;

namespace SchoolSystem.CLI.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            Engine.Teachers.Add(id, teacher);

            return $@"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id++} was created.";
        }
    }
}
