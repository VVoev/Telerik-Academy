namespace _03.StudentOperations.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        // Fields in class Student.
        private string firstName;
        private string lastName;
        private int age;
        private string facultyNumber;
        private string phoneNumber;
        private string emailAddress;
        private int groupUniversity;
        private ICollection<double> marks;
        private Group groupInfo;

        // Properties in class Student.
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Enter first name is necessary");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Enter last name is necessary");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Age can not be negative number.");
                }
                else
                {
                    this.age = value;
                }
            }
        }
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Enter faculty number.");
                }
                else
                {
                    this.facultyNumber = value;
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Enter phone number.");
                }
                else
                {
                    this.phoneNumber = value;
                }
            }
        }
        public string E_Mail
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                if (value == null)
                {
                    throw new FormatException("Enter e-mail address.");
                }
                else
                {
                    this.emailAddress = value;
                }
            }
        }
        public ICollection<double> Marks

        {
            get {return this.marks; }
            set { this.marks = value; }
        }
        public int MarksLength
        {
            get { return this.marks.Count(); }
        }
        public int Group
        {
            get { return this.groupUniversity; }
            set { this.groupUniversity = value; }
        }
        public Group GroupNumber
        {
            get { return this.groupInfo; }
            set
            {
                this.groupInfo = value;
            }
        }
        // Constructor for Problems 3, 4, 5 in class Student.
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        // Constructor for Problems 9-19 in class Student.
        public Student(string firstName, string lastName, string fn, string phoneNumber, string email, ICollection<double> marks, int group, Group groupInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = fn;
            this.PhoneNumber = phoneNumber;
            this.E_Mail = email;
            this.Marks = marks;
            this.GroupNumber = groupInfo;
            this.Group = group;
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
