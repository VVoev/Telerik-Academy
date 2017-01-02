namespace SoftwareAcademy.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;

    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> teacherCourses;

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You must enter a teacher name.");
                }
                this.name = value;
            }
        }

        public ICollection<ICourse> TeacherCourses
        {
            get
            {
                return new List<ICourse>();
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.teacherCourses = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.TeacherCourses.Add(course);
        }

        public override string ToString()
        {
            //Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            var sb = new StringBuilder();
            sb.Append(string.Format("Teacher: Name={0}; ", this.name));
            if (this.TeacherCourses.Count > 0)
            {
                sb.Append(string.Format("Courses=[{0}]; ", string.Join(", ",this.TeacherCourses)));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
