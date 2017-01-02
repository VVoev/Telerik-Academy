namespace _05.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Teacher
    {
        // Fields in class Teacher.
        private string firstName;
        private string lastName;
        private string fullName;
        private IEnumerable<Discipline> disciplines;

        // Properties in class Teacher.
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        public IEnumerable<Discipline> Disciplines
        {
            get {return this.disciplines; }
            set { this.disciplines = value; }
        }

        // Constructor in class Teacher.
        public Teacher(string name, IEnumerable<Discipline> disciplines)
        {
            this.FullName = name;
            this.Disciplines = disciplines;
        }
    }
}
