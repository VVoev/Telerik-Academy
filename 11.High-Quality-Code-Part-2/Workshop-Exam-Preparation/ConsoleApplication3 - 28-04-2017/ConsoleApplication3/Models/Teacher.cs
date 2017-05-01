namespace StudentApplication.Models
{
    public class Teacher
    {
        private string firstName;
        private string lastName;
        private Subject subject;

        public string FirstName { get; set; }

        public string LastName { get; set; }

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


        public Teacher(string firstName, string lastname, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Subject = subject;
        }

        public void AddMark(Student student, float studentMark)
        {
            var currentMark = new Mark(this.subject, studentMark);
            student.Marks.Add(currentMark);
        }
    }
}
