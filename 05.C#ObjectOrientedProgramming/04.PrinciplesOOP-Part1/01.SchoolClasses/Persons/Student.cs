namespace _01.SchoolClasses.Persons
{
    using System;

    public class Student : Person
    {

        // Fields in class Student.
        private int numberInClass;

        // Properties in class Student.
        public override string FullName
        {
            get { return string.Format("{0}", fullName); }
            set { fullName = value; }
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
            fullName = name;
            this.PersonalStudentNumber = number;
        }

        // Methods.
        public override string ToString()
        {
            return string.Format("{0} Number in class: {1}", this.FullName, this.PersonalStudentNumber);
        }
    }
}
