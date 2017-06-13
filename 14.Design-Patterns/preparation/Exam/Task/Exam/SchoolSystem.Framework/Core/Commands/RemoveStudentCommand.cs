﻿using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly ISchool school;

        public RemoveStudentCommand(ISchool school)
        {
            this.school = school;
        }
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.school.RemoveStudent(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
