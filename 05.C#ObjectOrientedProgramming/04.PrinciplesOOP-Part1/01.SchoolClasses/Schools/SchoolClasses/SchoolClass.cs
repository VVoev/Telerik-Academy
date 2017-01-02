namespace _01.SchoolClasses.Schools.SchoolClasses
{
    using Persons;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SchoolClass : IComparable<SchoolClass>
    {
        // Fields in class SchoolClass.
        private SchoolClassEnum idClass;
        private IEnumerable<Teacher> teachers;
        private IEnumerable<Student> students;

        // Properties in class SchoolClass.
        public SchoolClassEnum ClassID { get; }
        public IEnumerable<Teacher> Teachers
        {
            get { return this.teachers; }
            set
            {
                this.teachers = value;
            }
        }
        public IEnumerable<Student> Students
        {
            get { return this.students; }
            set
            {
                this.students = value;
            }
        }

        public SchoolClass(SchoolClassEnum id, IEnumerable<Student> students, IEnumerable<Teacher> teachers)
        {
            this.ClassID = id;
            this.Students = students;
            this.Teachers = teachers;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.ClassID.ToString());
            sb.AppendLine(string.Format("Teachers from class {0}:", this.ClassID.ToString()));
            sb.AppendLine("- " + string.Join(Environment.NewLine, this.Teachers));
            sb.AppendLine(string.Format("Students in class {0}:", this.ClassID));
            sb.AppendLine("- " + string.Join(Environment.NewLine + "- ", this.Students));

            return sb.ToString();
        }

        public int CompareTo(SchoolClass other)
        {
            return this.ClassID.CompareTo(other.ClassID);
        }
    }
}
