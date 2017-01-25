namespace SchoolApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private string schoolName;
        private ICollection<Course> schoolCourse;

        public School(string name)
        {
            this.SchoolName = name;
            this.schoolCourse = new List<Course>();
        }

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("School should have a name");
                }
                this.schoolName = value;
            }
        }

        public ICollection<Course> Courses
        {
            get { return this.schoolCourse; }
            set { this.schoolCourse = value; }
        }

        public void AddCourse(Course course)
        {
            if (this.Courses.Any(x=>x.Equals(course)))
            {
                throw new ArgumentException("Course is already presented in the school");
            }
            this.schoolCourse.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (!this.schoolCourse.Any(x => x.Equals(course)))
            {
                throw new ArgumentException("Cannot remove not existing course");
            }
            this.schoolCourse.Remove(course);
        }
    }
}
