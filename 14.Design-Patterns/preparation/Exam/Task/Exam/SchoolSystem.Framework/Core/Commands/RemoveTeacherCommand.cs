using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly ISchool school;

        public RemoveTeacherCommand(ISchool school)
        {
            this.school = school;
        }
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            var isFound = this.school.GetTeacher(teacherId);

            if (isFound == null)
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.school.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
