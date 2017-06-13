using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Contracts;
using System;
using SchoolSystem.Framework.Core.Commands.Factories.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly ICreateStudentFactory createStudentFactory;
        private readonly ISchool school;

        public CreateStudentCommand(ICreateStudentFactory createStudentFactory,ISchool school)
        {
            this.createStudentFactory = createStudentFactory;
            this.school = school;
        }
        private static int currentStudentId = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = createStudentFactory.CreateStudent(firstName, lastName, grade);
            this.school.AddStudent(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
  
   

   

}
