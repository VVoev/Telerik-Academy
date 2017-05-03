namespace SchoolSystem.Models
{
    using SchoolSystem.Abstracts;
    using SchoolSystem.Contracts;
    using SchoolSystem.Enums;

    public class Teacher : Person, ITeacher
    {
        private Subject subject;

        public Teacher(string firstName, string lastName, Subject subject) : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }

        public void AddMark(Student student, float currentMark)
        {
            var mark = new Mark(subject, currentMark);
            student.Marks.Add(mark);
        }
    }
}
