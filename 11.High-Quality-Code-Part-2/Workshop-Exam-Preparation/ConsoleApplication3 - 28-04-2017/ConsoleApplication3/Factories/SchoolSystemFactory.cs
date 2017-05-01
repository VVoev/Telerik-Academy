using StudentApplication.Models;
using System;

namespace StudentApplication
{
    public class SchoolSystemFactory : ISchoolSystemFactory
    {
        public IStudent CreateStudent(string firstName, string lastName, Grade grade)
        {
            return new Student(firstName, lastName, grade);
        }

        public ITeacher CreateTeacher(string firstName, string lastName, Subject subject)
        {
            return new Teacher(firstName, lastName, subject);
        }
    }
}
