using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Contracts;
using System;
using SchoolSystem.Framework.Core.Commands.Factories.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int currentTeacherId = 0;
        private readonly ICreateTeacherFactory teacherFactory;
        private readonly ISchool school;

        public CreateTeacherCommand(ICreateTeacherFactory teacherFactory, ISchool school)
        {
            this.teacherFactory = teacherFactory;
            this.school = school;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = teacherFactory.CreateTeacher(firstName, lastName, subject);
            this.school.AddTeacher(currentTeacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {currentTeacherId++} was created.";
        }
    } 
}
