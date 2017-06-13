using System;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        private readonly ICreateMarkFactory markFactory;
        public const int MaxStudentMarksCount = 20;



        public Teacher(string firstName, string lastName, Subject subject,ICreateMarkFactory markfactory)
            : base(firstName, lastName)
        {
            this.Subject = subject;
            this.markFactory = markfactory;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = markFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }

        public interface ICreateMarkFactory
        {
            IMark CreateMark(Subject subject, float value);
        }

        public class CreateMarkFactory : ICreateMarkFactory
        {
            public IMark CreateMark(Subject subject, float value)
            {
                return new Mark(subject, value);
            }
        }
    }
}
