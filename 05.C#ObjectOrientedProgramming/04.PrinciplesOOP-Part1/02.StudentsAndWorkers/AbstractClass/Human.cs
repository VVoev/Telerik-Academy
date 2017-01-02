namespace _02.StudentsAndWorkers.AbstractClass
{
    using System;
    public abstract class Human : IComparable<Human>
    {
        // Fields
        private string firstName;
        private string lastName;

        // Properties.
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
                    throw new ArgumentOutOfRangeException("Enter first name.");
                }
                this.firstName = value;
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
                this.lastName = value;
            }
        }

        // Constructor.
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public int CompareTo(Human other)
        {
            if (this.FirstName.CompareTo(other.FirstName) == 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            return this.FirstName.CompareTo(other.FirstName);
        }
    }
}
