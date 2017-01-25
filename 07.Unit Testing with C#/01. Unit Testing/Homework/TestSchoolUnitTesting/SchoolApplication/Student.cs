namespace SchoolApplication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;


    public class Student : IComparable<Student>
    {
        private string name;
        private int studentId;
        private IList studentsCount;

        public Student(string name,int id)
        {
            this.Name = name;
            this.StudentID = id;
            this.studentsCount = new List<int>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student must have a name");
                }
                this.name = value;
            }
        }

        public int StudentID
        {
            get
            {
                return this.studentId;
            }
            set
            {
                if(value<10000 || value > 99999)
                {
                    throw new ArgumentException("Id is not valid");
                }
                this.studentId = value;          }
        }

        public int CompareTo(Student other)
        {
            if (this.Name.CompareTo(other.Name) < 0)
            {
                return -1;
            }
           else  if (this.Name.CompareTo(other.Name) > 0)
            {
                return 1;
            }
            return 0;
        }


    
    }
}
