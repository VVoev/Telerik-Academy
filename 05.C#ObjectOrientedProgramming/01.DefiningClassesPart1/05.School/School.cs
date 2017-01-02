namespace _05.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class School
    {
        private IEnumerable<Teacher> teachers;
        private IEnumerable<Student> students;
        private SchoolClass schoolClasses;

        public IEnumerable<Student> Students
        {
            get {return this.students; }
            set { this.students = value; }
        }
    }
}
