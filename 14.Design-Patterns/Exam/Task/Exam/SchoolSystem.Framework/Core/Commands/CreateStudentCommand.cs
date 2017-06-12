using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    //public static class SchoolSystemFactory
    //{
    //    public static Student CreateStudent(string firstName,string lastName,Grade grade)
    //    {
    //        return new Student(firstName, lastName, grade);
    //    }

    //    public static Teacher CreateTeacher(string firstName, string lastName, Subject subject)
    //    {
    //        return new Teacher(firstName, lastName, subject);
    //    }
    //}

    public interface ISchoolFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);

        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);

        IMark CreateMark(Subject subject, float value);
    }

    public class CreateStudentCommand : ICommand
    {
        private int currentStudentId = 0;
        private readonly IAddStudent addStudent;
        private readonly IStudentFactory sFactory;

        public CreateStudentCommand(IStudentFactory sFactory,IAddStudent addStudent)
        {
            this.sFactory = sFactory;
            this.addStudent = addStudent;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            //var student = schoolFactory.CreateStudent(firstName, lastName, grade);          //Factory for all related things
            //var student = SchoolSystemFactory.CreateStudent(firstName, lastName, grade);   --Static Factory
            //var student = sFactory.CreateStudent(firstName, lastName, grade)               --Factory only for student
            var student = sFactory.CreateStudent(firstName, lastName, grade);          

            this.addStudent.AddStudent(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }

        public class StudenFactory : IStudentFactory
        {
            public IStudent CreateStudent(string firstname, string lastname, Grade grade)
            {
                return new Student(firstname, lastname, grade);
            }
        }

        public interface IStudentFactory
        {
            IStudent CreateStudent(string firstname, string lastname, Grade grade);
        }
    }
}
