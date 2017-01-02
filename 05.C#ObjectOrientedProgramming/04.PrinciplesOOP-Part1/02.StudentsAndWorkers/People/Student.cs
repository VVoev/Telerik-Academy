namespace _02.StudentsAndWorkers.People
{
    using AbstractClass;
    using System;

    public class Student : Human
    {
        private decimal grade;

        public Student(string firstName, string lastName, decimal grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public decimal Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value <= 0 && value > 12)
                {
                    throw new ArgumentOutOfRangeException("Grade must be positive integer between 1 and 12.");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format(this.FullName + ", Grade: {0}",this.Grade);
        }
    }
}
