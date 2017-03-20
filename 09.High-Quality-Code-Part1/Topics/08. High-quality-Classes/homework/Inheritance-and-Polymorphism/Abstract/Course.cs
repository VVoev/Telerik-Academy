using System.Collections.Generic;
using System.Linq;
using InheritanceAndPolymorphism.Validations;

namespace InheritanceAndPolymorphism.Abstract
{
    public abstract class Course
    {
        private string name;
        private string teacherName;

        protected Course(string courseName)
        {
            this.Name = courseName;
            this.Students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;     
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateIfNull(value, "Name");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                Validator.ValidateIfNull(value, "Teacher Name");
                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; }

        public void AddStudents(string [] students)
        {
            foreach (var student in students)
            {
                Validator.ValidateIfNull(student, "Student");
                this.Students.Add(student);
            }
        }

        public override string ToString()
        {
            return string.Format(string.Join(" ", this.Students),this.GetStudentsAsString());
        }

        public string GetStudentsAsString()
        {
            return string.Format("{{{0}}} ", string.Join(", ", this.Students.OrderBy(s => s)));
        }
    }
}
