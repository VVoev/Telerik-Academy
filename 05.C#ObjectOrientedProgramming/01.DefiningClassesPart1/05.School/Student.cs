namespace _05.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {

        // Fields in class Student.
        private string firstName;
        private string lastName;
        private string fullName;
        private int numberInClass;

        // Properties in class Student.
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        public int PersonalStudentNumber
        {
            get { return this.numberInClass; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Personal student number can be only positive number.");
                }
                this.numberInClass = value;
            }
        }

        // Constructor in class Teacher.
        public Student(string name, int number)
        {
            this.FullName = name;
            this.PersonalStudentNumber = number;
        }
    }
}
