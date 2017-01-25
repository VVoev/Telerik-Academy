namespace SchoolApplication
{

    using System;
    using System.Collections.Generic;


    public class Course
    {
        private string courseName;
        private ICollection<Student> numberOfStudents;

        public Course(string name)
        {
            this.CourseName = name;
            this.numberOfStudents = new List<Student>();
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course should have a name");
                }
                this.courseName = value;
            }
        }

        public ICollection<Student> NumberOfStudents
        {
            get { return this.numberOfStudents; }
            private set { this.numberOfStudents = value; }
        }

        public void AddStudentToCourse(Student student)
        {
            if (this.numberOfStudents.Count > 30)
            {
                throw new ArgumentException("Course is full,no place for more students");
            }
            this.numberOfStudents.Add(student);
        }

        public void RemovestudentFromCourse(Student student)
        {
            if (!this.numberOfStudents.Contains(student))
            {
                throw new ArgumentException("Not Existing Student");
            }
            this.numberOfStudents.Remove(student);
        }
    }
}
