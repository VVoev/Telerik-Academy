namespace _01.SchoolClasses.Persons
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Disciplines;

    public class Teacher : Person
    {
        // Fields in class Teacher.
        private IEnumerable<Discipline> disciplines;

        // Properties in class Teacher.
        public override string FullName
        {
            get { return string.Format("{0}", fullName); }
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
            fullName = name;
            this.Disciplines = disciplines;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.FullName);
            sb.AppendLine(string.Format("Disciplines:" + string.Join(Environment.NewLine, this.Disciplines)));
            return sb.ToString();
        }
    }
}
