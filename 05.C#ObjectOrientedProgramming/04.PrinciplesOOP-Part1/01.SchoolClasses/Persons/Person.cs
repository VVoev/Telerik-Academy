namespace _01.SchoolClasses.Persons
{
    using System;

    public abstract class Person : IComparable<Person>
    {
        protected string firstName;
        protected string lastName;
        protected string fullName;

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.firstName == null)
                {
                    throw new FormatException("Must enter a name");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName == null)
                {
                    throw new FormatException("Must enter a name");
                }
                this.lastName = value;
            }
        }
        public abstract string FullName{ get; set; }

        public int CompareTo(Person other)
        {
            return this.FullName.CompareTo(other.FullName);
        }
    }
}
