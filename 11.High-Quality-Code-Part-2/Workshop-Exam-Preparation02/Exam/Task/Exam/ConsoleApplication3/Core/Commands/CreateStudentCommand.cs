namespace SchoolSystem.Cli.Core.Commands
{
    using SchoolSystem.Cli.Models;
    using System.Collections.Generic;
    using SchoolSystem.Cli.Models.Enums;

    public class CreateStudentCommand : ICommand
    {
        private int id = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var secondName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);
            var student = new Student(firstName, secondName, grade);
            Engine.students.Add(this.id, student);
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {this.id++} was created.";
        }
    }
}
