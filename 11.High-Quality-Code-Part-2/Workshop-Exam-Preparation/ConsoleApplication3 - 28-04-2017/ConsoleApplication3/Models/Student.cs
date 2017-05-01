namespace StudentApplication.Models
{
    using System.Linq;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private Grade grade;
        private List<Mark> marks;
        private string lastName;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List <Mark> Marks { get; set; }

        public Student(string firstName, string lastName, Grade grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
            marks = new List<Mark>();
        }

        public string ListMarks()
        {
            var potatos = marks.Select(m => $"{m.Subject} => {m.CurrentMark}").ToList();
            return string.Join("\n", potatos);
        }
    }
}
