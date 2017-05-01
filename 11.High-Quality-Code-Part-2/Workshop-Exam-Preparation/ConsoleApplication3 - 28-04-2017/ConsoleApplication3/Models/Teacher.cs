using StudentApplication.Abstract;

namespace StudentApplication.Models
{
    public class Teacher : Person, ITeacher
    {
        private Subject subject;

        public Teacher(string firstName, string lastname, Subject subject) : base(
            firstName, lastname)
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

        public void AddMark(Student student, float studentMark)
        {
            var currentMark = new Mark(this.subject, studentMark);
            student.Marks.Add(currentMark);
        }
    }
}
