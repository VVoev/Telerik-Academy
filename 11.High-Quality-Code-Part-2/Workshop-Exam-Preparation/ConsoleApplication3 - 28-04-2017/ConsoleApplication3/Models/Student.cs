namespace StudentApplication.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private Grade grade;
        private List<Mark> marks;
        private string lastName;

        public Student(string firstName, string lastName, Grade grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
            this.marks = new List<Mark>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Mark> Marks { get; set; }

        public string ListMarks()
        {
            var potatos = this.marks.Select(m => $"{m.Subject} => {m.CurrentMark}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
