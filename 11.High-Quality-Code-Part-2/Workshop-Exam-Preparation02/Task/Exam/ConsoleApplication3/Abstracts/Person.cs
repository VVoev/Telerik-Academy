namespace SchoolSystem.Abstracts
{
    using Contracts;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                //Todo add validations
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
                //Todo add validations
                this.lastName = value;
            }
        }
    }
}
