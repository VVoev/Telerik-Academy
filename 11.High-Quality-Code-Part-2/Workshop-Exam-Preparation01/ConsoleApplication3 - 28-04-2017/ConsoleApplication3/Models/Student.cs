namespace SchoolSystemCli.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Enums;
    using SchoolSystem.CLI.Models.Abstraction;
    using SchoolSystem.CLI.Models.Contracts;

    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Grade grade) : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<Mark>();
        }

        public Grade Grade { get; private set; }

        public IList<Mark> Marks { get; private set; }

        public string ListMarks()
        {
            var potatos = this.Marks.Select(m => $"{m.Subject} => {m.MarkExam}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
