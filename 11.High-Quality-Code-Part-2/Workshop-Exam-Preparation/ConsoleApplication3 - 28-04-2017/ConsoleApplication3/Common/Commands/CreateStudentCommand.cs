using StudentApplication;
using StudentApplication.Models;
using System.Collections.Generic;

namespace ConsoleApplication3.Common.Commands
{
    public class CreateStudentCommand
    {
        private static int studentId = 0;

        public string Execute(IList<string> parameters)
        {
            string firstName = parameters[1];
            string lastName = parameters[2];
            Grade grade = (Grade)int.Parse(parameters[2]);

            Engine.Students.Add(studentId, new Student(firstName, lastName, grade));

            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {studentId++} was created.";
        }
    }
}
