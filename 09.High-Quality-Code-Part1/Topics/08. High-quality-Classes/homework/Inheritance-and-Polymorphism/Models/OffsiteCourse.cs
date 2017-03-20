using InheritanceAndPolymorphism.Abstract;
using InheritanceAndPolymorphism.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }

        public OffsiteCourse(string courseName)
            :base(courseName)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName,teacherName,students)
        {

            this.Town = town;
            this.Students = students;
        }


       

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
