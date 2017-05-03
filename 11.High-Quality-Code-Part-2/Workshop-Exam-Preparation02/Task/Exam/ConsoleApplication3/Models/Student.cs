namespace SchoolSystem.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Enums;
    using Abstracts;
    using Contracts;

    public class Student : Person, IStudent
    {

        public Grade Grades { get; set; }

        public IList<IMark> Marks { get; set; }


        public Student(string firstName, string lastName, Grade grades) : base(firstName, lastName)
        {
            this.Grades = grades;
            this.Marks = new List<IMark>();
        }

        public string ListMarks()
        {
            var listCurrentMarks = this.Marks.Select(m => $"{m.Subject} => {m.CurrentMark}").ToList();
            return string.Join("\n", listCurrentMarks);
        }
    }
}
