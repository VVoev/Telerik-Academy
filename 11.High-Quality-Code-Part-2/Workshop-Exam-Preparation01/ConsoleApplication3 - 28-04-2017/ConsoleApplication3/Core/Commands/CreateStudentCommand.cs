using SchoolSystem.CLI.Core;
using SchoolSystemCli.Models;
using SchoolSystemCli.Models.Enums;
using System;
using System.Collections.Generic;

namespace SchoolSystemCli
{
    public class CreateStudentCommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Students.Add(id, new Student(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])));
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
