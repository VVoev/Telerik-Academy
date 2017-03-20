using InheritanceAndPolymorphism.Abstract;
using InheritanceAndPolymorphism.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {

        private string lab;

        public LocalCourse(string courseName)
            : base(courseName)
        {
        }

        public LocalCourse(string courseName, string teacherName, string lab)
            : base(courseName, teacherName)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                Validator.ValidateIfNull(value, "lab");
                this.lab = value;
            }
        }


       

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
