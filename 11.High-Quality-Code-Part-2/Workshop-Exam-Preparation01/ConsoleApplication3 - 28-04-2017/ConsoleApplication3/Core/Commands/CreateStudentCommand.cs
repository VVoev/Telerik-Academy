using SchoolSystem.CLI.Core;
using SchoolSystemCli.Models;
using SchoolSystemCli.Models.Enums;
using System;
using System.Collections.Generic;

namespace SchoolSystemCli
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var student = new Student(firstName, lastName, grade);

            Engine.Students.Add(id, student);
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
