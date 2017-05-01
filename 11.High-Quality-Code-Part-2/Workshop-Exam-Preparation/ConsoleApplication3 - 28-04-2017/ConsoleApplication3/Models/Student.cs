namespace StudentApplication.Models
{
    using Abstract;
    using System.Collections.Generic;
    using System.Linq;

    public class Student : Person, IStudent
    {
        private Grade grade;
        private List<Mark> marks;

        public Student(string firstName, string lastName, Grade grade) : base(
            firstName, lastName)
        {
            this.grade = grade;
            this.marks = new List<Mark>();
        }

        public Grade Grade { get; private set; }

        public List<Mark> Marks { get; set; }

        public string ListMarks()
        {
            var marks = this.marks.Select(m => $"{m.Subject} => {m.CurrentMark}").ToList();
            return string.Join("\n", marks);
        }
    }
}
