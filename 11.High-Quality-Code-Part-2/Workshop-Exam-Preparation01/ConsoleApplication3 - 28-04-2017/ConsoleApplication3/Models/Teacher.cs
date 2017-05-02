namespace SchoolSystemCli.Models
{
    using System;
    using SchoolSystem.CLI.Models.Abstraction;
    using SchoolSystem.CLI.Models.Contracts;
    using SchoolSystemCli.Models.Enums;

    public class Teacher : Person, ITeacher
    {
        private int maxStudentMarksCount = 20;

        public Teacher(string firstName, string lastName, Subject subject) : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; private set; }

        public void AddMark(IStudent student, float currentMark)
        {
            var mark = new Mark(this.Subject, currentMark);
            if (student.Marks.Count > this.maxStudentMarksCount)
            {
                throw new ArgumentException($@"Students marks cannot exceed limit of {maxStudentMarksCount}");
            }

            student.Marks.Add(mark);
        }
    }
}
